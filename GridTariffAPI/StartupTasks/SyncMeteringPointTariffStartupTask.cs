using GridTariffApi.BigQuery.MeteringPointTariffSync;
using GridTariffApi.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.StartupTasks
{
    public class SyncMeteringPointTariffStartupTask : IStartupTask
    {
        private readonly IServiceProvider _serviceProvider;
        public SyncMeteringPointTariffStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public int GetExecutionOrder()
        {
            return 2;
        }

        public async Task Execute()
        {
            using var scope = _serviceProvider.CreateScope();
            var elviaDbContext = scope.ServiceProvider.GetRequiredService<ElviaDbContext>();
            var meteringPointTariffSynchronizer = scope.ServiceProvider.GetRequiredService<IMeteringPointTariffSynchronizer>();
            var elviaCompany = elviaDbContext.Company.FirstOrDefault();
            var bigQueryReader = scope.ServiceProvider.GetRequiredService<IBigQueryReader>();
            await meteringPointTariffSynchronizer.SynchronizeMeteringPointsAsync(elviaDbContext, bigQueryReader, elviaCompany, DateTimeOffset.UtcNow);
        }
    }
}
