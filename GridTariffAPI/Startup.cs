using Elvia.Configuration;
using Elvia.Telemetry;
using Elvia.Telemetry.Extensions;
using GridTariffApi.Auth;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Services.TariffType;
using GridTariffApi.Lib.Swagger;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using System;
using System.Runtime.InteropServices;

namespace GridTariff.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            GridTariffApiConfig gridTariffApiConfig = GetGridTariffApiConfig();

            services.AddSingleton (gridTariffApiConfig);

            services.AddStandardElviaTelemetryLoggingWorkerService(_configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key"), writeToConsole: true, retainTelemetryWhere: telemetryItem => telemetryItem switch
            {
                DependencyTelemetry d => false,
                RequestTelemetry r => false,
                _ => true,
            });
            services.AddTransient<ITariffTypeService, TariffTypeService>();
            services.AddTransient<ITariffQueryService, TariffQueryService>();
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(gridTariffApiConfig.DBConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            services.AddSwaggerConfiguration(swaggerSettings);
            ConfigureAuth(services, gridTariffApiConfig.Username, gridTariffApiConfig.Password);
        }

        private GridTariffApiConfig GetGridTariffApiConfig()
        {
            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig();
            gridTariffApiConfig.DBConnectionString = _configuration.EnsureHasValue("kunde:kv:sql:kunde-sqlserver:NettTariff:connection-string");
            gridTariffApiConfig.InstrumentationKey = _configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key");
            gridTariffApiConfig.Username = _configuration.EnsureHasValue("kunde:kv:nett-tariff-api:username");
            gridTariffApiConfig.Password = _configuration.EnsureHasValue("kunde:kv:nett-tariff-api:password");
            gridTariffApiConfig.MinStartDateAllowedQuery = _configuration.GetValue<DateTime>("minStartDateAllowedQuery");
            gridTariffApiConfig.TimeZoneForQueries = NorwegianTimeZoneInfo();
            return gridTariffApiConfig;
        }

        protected virtual void ConfigureAuth(IServiceCollection services, string user, string password)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddSingleton(config =>
                new AuthenticationConfig(user, password));
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
        private static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }
    }
}
