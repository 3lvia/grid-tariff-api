using Elvia.Configuration;
using Elvia.Telemetry;
using GridTariffApi.Database;
using GridTariffApi.StartupTasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build().MigrateDatabase<ElviaDbContext>();

            var logger = host.Services.GetRequiredService<ITelemetryInsightsLogger>();
            var startupTasks = host.Services.GetServices<IStartupTask>().OrderBy(x => x.GetExecutionOrder());
            foreach (var startupTask in startupTasks)
            {
                try
                {
                    logger.TrackEvent($"Executing startupptask with name {startupTask.GetType().Name}");
                    await startupTask.Execute();
                    logger.TrackEvent($"Executed startupptask with name {startupTask.GetType().Name}");
                }
                catch (Exception e)
                {
                    logger.TrackException(e);
                }
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, config) => config.AddHashiVaultSecrets());
                    webBuilder.UseStartup<Startup>();
                });

        public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
        {
            var serviceScopeFactory = (IServiceScopeFactory)host
                .Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<T>();
                dbContext.Database.Migrate();
            }
            return host;
        }
    }
}
