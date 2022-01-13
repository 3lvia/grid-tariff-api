using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Elvia.Configuration;
using Elvia.Telemetry;
using Elvia.Telemetry.Extensions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using GridTariffApi.Auth;
using GridTariffApi.Elvid;
using GridTariffApi.Extensions;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Interfaces;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services;
using GridTariffApi.Lib.Swagger;
using GridTariffApi.Mdmx;
using GridTariffApi.Metrics;
using GridTariffApi.Middleware;
using GridTariffApi.Services;
using GridTariffApi.Synchronizer.Lib.Config;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IO;
using Prometheus;

namespace GridTariffApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            AddCompression(services);

            services.AddSingleton<RecyclableMemoryStreamManager>();
            services.AddScoped<RequestLogAuthEnricher>();

            //v1
            GridTariffApiConfig gridTariffApiConfig = GetGridTariffApiConfig();
            services.AddSingleton(gridTariffApiConfig);
            GridTariffApiSynchronizerConfig gridTariffApiSynchronizerConfig = GetGridTariffApiSynchronizerConfig();
            services.AddSingleton(gridTariffApiSynchronizerConfig);

            var bigQueryClient = CreateBigQueryClient(gridTariffApiSynchronizerConfig);
            services.AddTransient(u => bigQueryClient);
            services.AddTransient<IBigQueryReader, BigQueryReader>();
            services.AddTransient<IGridTariffApiSynchronizer, GridTariffApiSynchronizer>();
            services.AddTransient<GridTariffApi.Lib.Services.Pilot.ITariffTypeService, GridTariffApi.Lib.Services.Pilot.TariffTypeService>();
            services.AddTransient<GridTariffApi.Lib.Services.Pilot.ITariffQueryService, GridTariffApi.Lib.Services.Pilot.TariffQueryService>();
            services.AddTransient<IServiceHelper, ServiceHelper>();
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(gridTariffApiConfig.DBConnectionString));

            //v2
            services.AddSingleton<ITariffRepository, TariffRepositoryFile>();
            services.AddSingleton<IHolidayRepository, HolidayRepositoryFile>();
            services.AddSingleton<IMeteringPointTariffRepository, MeteringPointTariffRepositoryEf>();
            services.AddSingleton<IMeteringPointMaxConsumptionRepository, MeteringPointMaxConsumptionRepository>();
            services.AddSingleton<ITariffPriceCache, TariffPriceCache>();
            services.AddTransient<GridTariffApi.Lib.Services.IObjectConversionHelper, GridTariffApi.Lib.Services.ObjectConversionHelper>();
            services.AddTransient<GridTariffApi.Lib.Services.ITariffQueryService, GridTariffApi.Lib.Services.TariffQueryService>();
            services.AddTransient<GridTariffApi.Lib.Services.ITariffTypeService, GridTariffApi.Lib.Services.TariffTypeService>();
            services.AddTransient<IControllerValidationHelper, ControllerValidationHelper>();
            services.AddScoped<ILoggingDataCollector, LoggingDataCollector>();
            services.AddSingleton<IMetricsLogger, MetricsLogger>();
            
            // Elvid
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddSingleton(new ClientCredentialsConfiguration(
                Configuration.EnsureHasValue("kunde:kv:elvid:kunde-grid-tariff-api:tokenendpoint"),
                Configuration.EnsureHasValue("kunde:kv:elvid:kunde-grid-tariff-api:clientid"),
                Configuration.EnsureHasValue("kunde:kv:elvid:kunde-grid-tariff-api:clientsecret")
            ));
            services.AddSingleton<IAccessTokenService, AccessTokenService>();

            // Mdmx
            services.AddSingleton(new MdmxConfig
            {
                HostAddress = Configuration.EnsureHasValue("mdmx:host-address"),
                TimeZoneForMonthLimiting = gridTariffApiConfig.TimeZoneForQueries
            });
            services.AddScoped<IMdmxClient, MdmxClient>();

            services.AddStandardElviaTelemetryLogging(Configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key"), writeToConsole: true); 

            services.AddCronJob<ScheduledGridTariffApiSynchronizer>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"0 5 * * *";      //every day at 05:00
            });

            var swaggerSettings = Configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
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
            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig
            {
                DBConnectionString = Configuration.EnsureHasValue("kunde:kv:sql:kunde-sqlserver:NettTariff:connection-string"),
                InstrumentationKey = Configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key"),
                Username = Configuration.EnsureHasValue("kunde:kv:nett-tariff-api:username"),
                Password = Configuration.EnsureHasValue("kunde:kv:nett-tariff-api:password"),
                MinStartDateAllowedQuery = Configuration.GetValue<DateTime>("minStartDateAllowedQuery"),
                TimeZoneForQueries = NorwegianTimeZoneInfo(),
                MaxConsumptionCacheTimeout = TimeSpan.FromHours(1)
            };
            return gridTariffApiConfig;
        }

        private GridTariffApiSynchronizerConfig GetGridTariffApiSynchronizerConfig()
        {
            var gridTariffApiSynchronizerConfig = new GridTariffApiSynchronizerConfig
            {
                BigQueryProjectId = Configuration.EnsureHasValue("bad:kv:info:bigquery:bad:project-id"),
                BigQueryAccountKey = Configuration.EnsureHasValue("bad:kv:bigquery:bad:service-account-key-sa-bigquery"),
                InstrumentationKey = Configuration.EnsureHasValue("kunde:kv:appinsights:kunde:instrumentation-key")
            };
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

            var authority = Configuration.EnsureHasValue("kunde:kv:elvid:generic:authority");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.Authority = authority;
                  options.TokenValidationParameters.ValidateAudience = false;
                  options.TokenValidationParameters.ValidateIssuer = false;

                  IdentityModelEventSource.ShowPII = true;
                  options.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = (authenticationFailedContext) =>
                      {
                          var errorLogEnricher = authenticationFailedContext.HttpContext.RequestServices
                              .GetRequiredService<RequestLogAuthEnricher>();
                          errorLogEnricher.OnAuthenticationFailed(authenticationFailedContext);
                          return Task.CompletedTask;
                      },
                      OnForbidden = (forbiddenContext) =>
                      {
                          // Kan ikke se at denne kalles ved HTTP 403 (Forbidden). Men vi logger detaljer om claims/scopes fra JWT token, som kan gi nyttig info ved feilsøking.
                          var errorLogEnricher = forbiddenContext.HttpContext.RequestServices
                              .GetRequiredService<RequestLogAuthEnricher>();
                          errorLogEnricher.OnForbidden(forbiddenContext);
                          return Task.CompletedTask;
                      },
                  };
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
            app.UseMiddleware<RequestLogEnricherMiddleware>();
            app.UseMiddleware<CustomMetricsMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics(); // This adds the '/metrics' url for Prometheus scraping
            });
            var swaggerSettings = Configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            app.UseSwaggerConfiguration(swaggerSettings);
        }
        public static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }

        private static void AddCompression(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
        }

    }
}
