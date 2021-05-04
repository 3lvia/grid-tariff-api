using Microsoft.AspNetCore.Authorization;

namespace GridTariffApi.Extensions
{
    public static class PolicyExtensions
    {
        public static bool HasScope(this AuthorizationHandlerContext context, string scope)
        {
            return context.HasClaim("scope", scope);
        }
        public static bool HasClaim(this AuthorizationHandlerContext context, string claimType, string claimValue)
        {
            return context.User.HasClaim(claim => claim.Type == claimType && claim.Value == claimValue);
        }
    }
}
