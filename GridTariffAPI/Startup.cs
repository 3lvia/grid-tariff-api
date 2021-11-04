using Elvia.Configuration;
using Elvia.Telemetry;
using Elvia.Telemetry.Extensions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using GridTariffApi.Auth;
using GridTariffApi.Extensions;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Services.TariffType;
using GridTariffApi.Lib.Swagger;
using GridTariffApi.Services.V2;
using GridTariffApi.Synchronizer.Lib.Config;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Authentication;
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
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Text;
using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Services.V2;

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

            AddAuthorizations(services);

//v1
            GridTariffApiConfig gridTariffApiConfig = GetGridTariffApiConfig();
            services.AddSingleton(gridTariffApiConfig);
            GridTariffApiSynchronizerConfig gridTariffApiSynchronizerConfig = GetGridTariffApiSynchronizerConfig();
            services.AddSingleton(gridTariffApiSynchronizerConfig);

            var bigQueryClient = CreateBigQueryClient(gridTariffApiSynchronizerConfig);
            services.AddTransient(u => bigQueryClient);
            services.AddTransient<IBigQueryReader, BigQueryReader>();
            services.AddTransient<IGridTariffApiSynchronizer, GridTariffApiSynchronizer>();
            services.AddTransient<GridTariffApi.Lib.Services.TariffType.ITariffTypeService, GridTariffApi.Lib.Services.TariffType.TariffTypeService>();
            services.AddTransient<GridTariffApi.Lib.Services.TariffQuery.ITariffQueryService, GridTariffApi.Lib.Services.TariffQuery.TariffQueryService>();
            services.AddTransient<IServiceHelper, ServiceHelper>();
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(gridTariffApiConfig.DBConnectionString));

            //v2
            services.AddSingleton<ITariffPersistence, TariffPersistenceFile>();
            services.AddTransient<ITariffPriceCache, TariffPriceCache>();
            services.AddTransient<GridTariffApi.Lib.Services.V2.ITariffQueryService, GridTariffApi.Lib.Services.V2.TariffQueryService>();

//some testing
            ITariffPriceCache tariffPriceCache = new TariffPriceCache(new TariffPersistenceFile());
            var tariffQueryService = new GridTariffApi.Lib.Services.V2.TariffQueryService(tariffPriceCache);
            tariffQueryService.QueryTariffAsync("normal_daynight1", new DateTime(2021, 01, 01), new DateTime(2021, 12, 3));
            tariffQueryService.QueryTariffAsync("company_ls_dn1", new DateTime(2021, 01, 01), new DateTime(2021, 12, 3));

            

            services.AddStandardElviaTelemetryLogging(_configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key"), writeToConsole: true, retainTelemetryWhere: telemetryItem => telemetryItem switch
            {
                DependencyTelemetry d => false,
                RequestTelemetry r => false,
                _ => true,
            });

            services.AddCronJob<ScheduledGridTariffApiSynchronizer>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"0 5 * * *";      //every day at 05:00
            });

            var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            services.AddSwaggerConfiguration(swaggerSettings);
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });

            ConfigureAuth(services, gridTariffApiConfig.Username, gridTariffApiConfig.Password);
        }

        private static void AddAuthorizations(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder("BasicAuthentication", JwtBearerDefaults.AuthenticationScheme)
                    .RequireAssertion(c => {
                        return c.HasScope("kunde.grid-tariff-api.machineaccess") || c.User?.Identity?.AuthenticationType =="BasicAuthentication";
                    })
                    .Build();
            });
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

        private GridTariffApiSynchronizerConfig GetGridTariffApiSynchronizerConfig()
        {
            var gridTariffApiSynchronizerConfig = new GridTariffApiSynchronizerConfig();
            gridTariffApiSynchronizerConfig.BigQueryProjectId = _configuration.EnsureHasValue("bad:kv:info:bigquery:bad:project-id");
            gridTariffApiSynchronizerConfig.BigQueryAccountKey = _configuration.EnsureHasValue("bad:kv:bigquery:bad:service-account-key-sa-bigquery");
            gridTariffApiSynchronizerConfig.InstrumentationKey = _configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key");
            return gridTariffApiSynchronizerConfig;
        }

        private static BigQueryClient CreateBigQueryClient(GridTariffApiSynchronizerConfig gridTariffApiSynchronizerConfig)
        {
            var jsonCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(gridTariffApiSynchronizerConfig.BigQueryAccountKey));
            var bigQueryClient = BigQueryClient.Create(gridTariffApiSynchronizerConfig.BigQueryProjectId, credential: GoogleCredential.FromJson(jsonCredentials));
            return bigQueryClient;
        }

        protected virtual void ConfigureAuth(IServiceCollection services, string user, string password)
        {

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddSingleton(config =>
                new AuthenticationConfig(user, password));

            var authority = _configuration.EnsureHasValue("kunde:kv:elvid:generic:authority");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.Authority = authority;
                  options.TokenValidationParameters.ValidateAudience = false;
                  options.TokenValidationParameters.ValidateIssuer = false;
              });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

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
