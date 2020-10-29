using Elvia.Configuration;
using Elvia.Telemetry;
using Elvia.Telemetry.Extensions;
using Kunde.TariffApi.Config;
using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Services.TariffQuery;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using System.IdentityModel.Tokens.Jwt;

namespace Kunde.TariffApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireClaim("scope", "kunde.nett-tariff-api.machineaccess")
                    .Build();
                options.DefaultPolicy = policy;
            });

            services.AddControllers();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            var instrumentationKey = _configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key");
            services.AddStandardElviaTelemetryLogging(instrumentationKey);
            var authority = _configuration.EnsureHasValue("kunde:kv:elvid:generic:authority");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.Authority = authority;
                  options.TokenValidationParameters.ValidateAudience = false; /*utkommentert fordi vi starter med elvid, ikke hid*/
                  options.TokenValidationParameters.ValidateIssuer = false;
              });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddTransient<ITariffTypeService, TariffTypeService>();
            services.AddTransient<ITariffQueryService, TariffQueryService>();
            var connectionString = _configuration.EnsureHasValue("kunde:kv:sql:kunde-sqlserver:NettTariff:connection-string");
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            var tariffQueryValidationSettings = _configuration.GetSection("TariffQueryValidationSettings").Get<TariffQueryValidationSettings>();
            services.AddSingleton(tariffQueryValidationSettings);
            var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            services.AddSwaggerConfiguration(swaggerSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.AddStandardElviaAspnetMetrics(); // After AddRouting(), and before UseEndpoints()
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics(); // This adds the '/metrics' url for Prometheus scraping
            });
            var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            app.UseSwaggerConfiguration(swaggerSettings);
        }
    }
}
