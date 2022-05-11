using Elvia.Configuration;
using Elvia.Telemetry;
using GridTariffApi.Database;
using GridTariffApi.StartupTasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable CS4014

namespace GridTariffApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build().MigrateDatabase<ElviaDbContext>();

            var logger = host.Services.GetRequiredService<ITelemetryInsightsLogger>();
            logger.TrackEvent("Startup");
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                try
                {
                    Console.WriteLine($"Unhandled exception occured: {((Exception)eventArgs.ExceptionObject)?.GetType()}. Attempting to log exception to application insights.");
                    logger.TrackException((Exception)eventArgs.ExceptionObject, new { eventArgs.IsTerminating, SenderType = sender?.GetType().ToString() });
                    logger.Flush();
                }
                catch (Exception loggingException)
                {
                    Console.WriteLine($"Exception while logging unhandled exception. Unhandled exception (#1): {eventArgs}. Exception while logging original exception (#2): {loggingException}");
                    // Don't throw (the loggingException) - let the original unhandled exception take its course
                }
            }; 

            var startupTasks = host.Services.GetServices<IStartupTask>().OrderBy(x => x.GetExecutionOrder()).ToList();
            RunStartupTasks(startupTasks, logger); // Don't wait - it takes a long time (and the database is initiated in all environments, so we need to get the service up and running without waiting for metering point products to be fully updated.
            logger.TrackEvent("StartupTasksDispatched_StartingHost");
            await host.RunAsync();
        }

        private static async Task RunStartupTasks(List<IStartupTask> startupTasks, ITelemetryInsightsLogger logger)
        {
            foreach (var startupTask in startupTasks)
            {
                try
                {
                    logger.TrackEvent($"Executing startup task {startupTask.GetType().Name}");
                    await startupTask.Execute();
                    logger.TrackEvent($"Executed startup task {startupTask.GetType().Name}");
                }
                catch (Exception e)
                {
                    logger.TrackException(e);
                }
            }
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
