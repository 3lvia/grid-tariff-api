using System.Diagnostics;
using System.Threading.Tasks;
using GridTariffApi.Lib.Interfaces;
using GridTariffApi.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace GridTariffApi.Middleware
{
    /// <summary>
    /// This middleware component is plugged into the http pipeline and records custom metrics for grid-tariff-api
    /// </summary>
    public class CustomMetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsLogger _logger;

        public CustomMetricsMiddleware(RequestDelegate next, IMetricsLogger logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            string controller = "";
            string action = "";
            string method = "";
            string responseCode = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                controller = context.GetRouteValue("controller")?.ToString();
                action = context.GetRouteValue("action")?.ToString();
                method = context.Request.Method; // POST/GET...
                await _next(context);
                responseCode = context.Response?.StatusCode.ToString();
            }
            catch
            {
                responseCode = "500";
                throw;
            }
            finally
            {
                stopwatch.Stop();
                var elapsedTimeSpan = stopwatch.Elapsed;
                var loggingDataCollector = context.RequestServices.GetRequiredService<ILoggingDataCollector>(); // Scoped instance used to collect details other places. The middleware is not scoped, so we need to aquire the scoped instance from the context services.
                var tariffTimeSpan = loggingDataCollector?.TariffTimeSpan;
                // We won't include request where the authentication or validation fails (400 bad request, 401 unauthorized etc), as the TariffTimeSpan won't be set. But that's included in the standard metrics.
                if(tariffTimeSpan.HasValue)
                {
                    _logger.LogRequestMetrics(controller, action, method, responseCode, tariffTimeSpan.Value, elapsedTimeSpan);
                }
            }
        }
    }
}
