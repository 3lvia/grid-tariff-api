using Microsoft.AspNetCore.Authorization;

namespace Kunde.TariffApi.Extensions
{
    public static class AuthorizationHandlerContextExtensions
    {
        public static bool HasScope(this AuthorizationHandlerContext context, string scope)
        {
            return context.User.HasClaim(claim => claim.Type == "scope" && claim.Value == scope);
        }
    }
}
