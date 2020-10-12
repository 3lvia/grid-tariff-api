using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Elvia.Configuration;
using Elvia.Telemetry;
using Kunde.TariffApi.Config;
using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Extensions;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.Swagger;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            //services.AddAuthorization(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .RequireAssertion(context => context.HasScope("louvre.imageimport") || context.HasScope("louvre.imageimport-useraccess") || context.HasScope("louvre.imageimport-lowpriority"))
            //        .Build();
            //    options.DefaultPolicy = policy;
            //});

            services.AddControllers();

            //var instrumentationKey = _configuration.EnsureHasValue("louvre:kv:appinsights:louvre:instrumentation-key");
            //services.AddStandardElviaTelemetryLogging(instrumentationKey, retainTelemetryWhere: telemetryItem => telemetryItem switch
            //{
            //    DependencyTelemetry d => false,
            //    _ => true,
            //});

            //var authority = _configuration.EnsureHasValue("louvre:kv:elvid:generic:authority");
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //  .AddJwtBearer(options =>
            //  {
            //      options.Authority = authority;
            //      options.TokenValidationParameters.ValidateAudience = false;
            //      options.TokenValidationParameters.ValidateIssuer = false;
            //  });
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddTransient<ITariffTypeService, TariffTypeService>();
            //            services.AddTransient<TariffContext, TariffContext>();


            DBConfig dBConfig = _configuration.GetSection("DBConfig").Get<DBConfig>();
            services.AddDbContext<TariffContext>(options => options.UseSqlServer(dBConfig.ConnectionString));


            //var swaggerSettings = _configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            //services.AddSwaggerConfiguration(swaggerSettings);
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
