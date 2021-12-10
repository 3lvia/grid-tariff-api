using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GridTariffApi.Middleware
{
    /// <summary>
    /// Used for adding error details to the error logging performed by ErrorLoggerMiddleware. Take this class as a DI dependency and expand with new fields as needed.
    /// (The RequestLogEnricherMiddleware is not scoped, and cannot be used as a DI dependency for per-request instances).
    /// </summary>
    public class RequestLogAuthEnricher
    {
        public string AuthenticationFailedDetails { get; protected set; }
        public string AuthorizationFailedDetails { get; protected set; }

        public void OnAuthenticationFailed(AuthenticationFailedContext authenticationFailedContext)
        {
            AuthenticationFailedDetails = $"Authentication exception message: {authenticationFailedContext.Exception?.Message ?? "<empty>"}";
        }

        public void OnForbidden(ForbiddenContext forbiddenContext)
        {
            AuthorizationFailedDetails = $"Authorization failure message: {forbiddenContext.Result?.Failure?.Message ?? "<empty - does the jwt token have the required scope?>"}";
        }
    }
}
