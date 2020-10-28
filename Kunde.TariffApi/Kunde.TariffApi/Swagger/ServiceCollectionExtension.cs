using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;

namespace Kunde.TariffApi.Swagger
{
    /// <summary>
    /// Excension to load Swagger
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, SwaggerSettings settings)
        {
            settings.EnsureValid();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example value: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.SwaggerDoc(settings.Version, new OpenApiInfo
                {
                    Version = settings.Version,
                    Title = settings.Title,
                    Description = settings.Description,
                });
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "GridTariffAPI.xml"));
            });

            return services;
        }

        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="application"></param>
        /// <param name="settings"></param>
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder application, SwaggerSettings settings)
        {
            settings.EnsureValid();
            var servers = new List<OpenApiServer>
            {
                new OpenApiServer { Url = settings.RelativeUrl },
            };

            application.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swaggerDoc, _) => swaggerDoc.Servers = servers);
            });

            if (settings.UseSwaggerUI.Value)
            {
                application.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"{settings.PathPrefix}/swagger/v1/swagger.json", settings.Title);
                });
            }

            return application;
        }
    }
}
