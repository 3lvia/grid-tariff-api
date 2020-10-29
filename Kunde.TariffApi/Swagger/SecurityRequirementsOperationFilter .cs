using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Kunde.TariffApi.Swagger
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        private static readonly OpenApiResponse _unauthorized = new OpenApiResponse { Description = "Unauthorized" };

        private static readonly OpenApiResponse _forbidden = new OpenApiResponse { Description = "Forbidden" };

        private static readonly OpenApiSecurityScheme _securityScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        };

        private static readonly List<OpenApiSecurityRequirement> _securityRequirements = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                { _securityScheme, new string[0] },
            }
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var allowAnonymousAttributes = context.MethodInfo
                .GetCustomAttributes(inherit: false)
                .OfType<AllowAnonymousAttribute>();

            if (allowAnonymousAttributes.Any())
            {
                return;
            }

            operation.Responses.Add("401", _unauthorized);
            operation.Responses.Add("403", _forbidden);
            operation.Security = _securityRequirements;
        }
    }
}
