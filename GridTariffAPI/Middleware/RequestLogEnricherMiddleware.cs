using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elvia.Telemetry;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;

namespace GridTariffApi.Middleware
{
    /// <summary>
    /// This middleware component is plugged into the http pipeline and adds request-, response-, debug- and authentication info to the standard request telemetry.
    /// </summary>
    public class RequestLogEnricherMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITelemetryInsightsLogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestLogEnricherMiddleware(RequestDelegate next, ITelemetryInsightsLogger logger, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = recyclableMemoryStreamManager;
        }

        // Add extra info to all calls to the main API. And to other operations when they are unsuccessful.
        private static bool ShouldLogForResponseContext(HttpContext ctx)
        {
            var fullLoggingPathStrings = new[] { "tariff" };
            var lowercasePath = ctx.Request.Path.ToString().ToLower();
            return fullLoggingPathStrings.Any(fullLoggingPathString => lowercasePath.Contains(fullLoggingPathString))
                   || ctx.Response.StatusCode >= 400;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestBody = null;
            string responseBody = null;
            bool exceptionOccured = false;
            string exceptionInfo = null;
            try
            {
                requestBody = await GetRequestBody(context); // The request string needs to be extracted before performing next(), because it is not always available after the downstream processing. So we'll extract it even in cases where we shouldn't log, but that's acceptable.

                responseBody = await GetResponseBodyAndPerformDownstreamProcessing(context, 3000);
            }
            catch (Exception ex)
            {
                exceptionOccured = true;
                exceptionInfo = $"Exception while logging/processing request in {nameof(RequestLogEnricherMiddleware)}: {ex}";
                throw;
            }
            finally
            {
                try
                {
                    if (ShouldLogForResponseContext(context) || exceptionOccured)
                    {
                        var enricher = context.RequestServices.GetRequiredService<RequestLogAuthEnricher>(); // Scoped instance used to collect error details other places. The middleware is not scoped, so we need to aquire the scoped instance from the context services.

                        var requestTelemetry = context.Features.Get<RequestTelemetry>(); // Add fields to automatic request telemetry
                        if(requestTelemetry != null)
                        {
                            requestTelemetry.Properties["RequestBody"] = string.IsNullOrEmpty(requestBody) ? "<empty>" : requestBody;
                            requestTelemetry.Properties["ResponseBody"] = BodyStringForTelemetryProperty(responseBody, exceptionOccured);
                            requestTelemetry.Properties["ExceptionInfo"] = exceptionInfo;
                            requestTelemetry.Properties["JwtTokenDetails"] = GetJwtBearerTokenDetailsWithoutSignature(context);
                            requestTelemetry.Properties["AuthenticationFailedDetails"] = enricher.AuthenticationFailedDetails;
                            requestTelemetry.Properties["AuthorizationFailedDetails"] = enricher.AuthorizationFailedDetails;
                            requestTelemetry.Properties["ApiVersion"] = GetApiVersion(context);
                        }
                    }
                }
                catch (Exception tracingException)
                {
                    try
                    {
                        _logger.TrackException(new ApplicationException($"Exception while trying to enhance request telemetry in {nameof(RequestLogEnricherMiddleware)}", tracingException));
                        _logger.Flush();
                    }
                    catch
                    {
                        // Best effort - we've tried to log the exception that occured during tracing, but that failed. Don't make a big thing out of it.
                    }

                    if (!exceptionOccured)
                    {
                        throw; // The original thing we tried to trace wasn't an exception. Let's draw attention to the tracing exception.
                    }

                    // We've tried logging the exception that occured during tracing. Don't throw, but continue focusing on the original exception from request handling.
                }
            }
        }

        private static string BodyStringForTelemetryProperty(string responseBody, bool exceptionOccured)
        {
            if (!string.IsNullOrEmpty(responseBody))
            {
                return responseBody;
            }

            return exceptionOccured ? "<empty due to exception>" : "<empty>";
        }

        /// <summary>
        /// Return the header and payload parts of the jwt bearer token for logging. The signature part is stripped, so the logged information cannot be used as a token. If we cannot extract the jwt token header and payload, return a string describing that.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetJwtBearerTokenDetailsWithoutSignature(HttpContext context)
        {
            try
            {
                string authorizationHeaderValue = context.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorizationHeaderValue))
                {
                    return "\"Authorization\" header field not found";
                }

                if (!authorizationHeaderValue.StartsWith("Bearer "))
                {
                    return "No Bearer token in header";
                }

                string jwtTokenRaw = authorizationHeaderValue.Substring("Bearer ".Length);
                var tokenPartsRaw = jwtTokenRaw.Split(".");
                if (tokenPartsRaw.Length != 3)
                {
                    return "Bearer token present, but it is not three sections separated by \".\"";
                }

                var jwtHeaderRaw = tokenPartsRaw[0];
                var jwtPayloadRaw = tokenPartsRaw[1];
                var jwtHeaderDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jwtHeaderRaw));
                var jwtPayloadDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jwtPayloadRaw));
                return $"JWT header: {jwtHeaderDecoded}\nJWT payload: {jwtPayloadDecoded}";
            }
            catch (Exception ex)
            {
                return $"Exception while extracting jwt bearer token: {ex}";
            }
        }

        private async Task<string> GetRequestBody(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            var body = ReadStreamInChunks(requestStream);
            context.Request.Body.Position = 0;
            return body;
        }

        private async Task<string> GetResponseBodyAndPerformDownstreamProcessing(HttpContext context, int maxLength)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            string body = null;
            try
            {
                await _next(context);
            }
            finally
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                body = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream; // Avoid having our recyclable memory stream remaining as the Response.Body. It might get disposed, which will interfere with upstream processing.
            }

            // TODO: optimize
            if (body.Length > maxLength)
            {
                body = body[..maxLength] + "...";
            }

            return body;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                    0,
                    readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }

        public static string GetApiVersion(HttpContext ctx)
        {
            // Example: http://grid-tariff-api.elvia.io/api/1/tariffquery/meteringpointsgridtariffs for API version "1"
            var lowercasePath = ctx.Request.Path.ToString().ToLower();

            var apiVersionPrefix = "/api/";
            var startIndex = lowercasePath.IndexOf(apiVersionPrefix, StringComparison.InvariantCulture);

            if (startIndex < 0)
            {
                return null;
            }

            startIndex = startIndex + apiVersionPrefix.Length;
            if (startIndex >= lowercasePath.Length)
            {
                return null;
            }

            var stopIndex = lowercasePath.IndexOf("/", startIndex, StringComparison.InvariantCulture);

            if (stopIndex < 0)
            {
                return null;
            }

            var version = lowercasePath.Substring(startIndex, stopIndex - startIndex);
            return version;
        }
    }
}