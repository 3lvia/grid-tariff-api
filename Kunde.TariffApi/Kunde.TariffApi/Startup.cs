using Elvia.Configuration;
using Elvia.Telemetry;
using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Extensions;
using Kunde.TariffApi.Services.TariffQuery;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
//                    .RequireAuthenticatedUser()
                    .RequireAssertion(context => context.HasScope("kunde.nett-tariff-api.machineaccess"))
                    .Build();
                options.DefaultPolicy = policy;
            });

            services.AddControllers();

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
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(connectionString));

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            //app.UseSwaggerConfiguration(swaggerSettings);

        }
    }
}
