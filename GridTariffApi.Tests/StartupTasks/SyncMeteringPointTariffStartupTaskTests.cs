using GridTariffApi.BigQuery.MeteringPointTariffSync;
using GridTariffApi.Database;
using GridTariffApi.Model;
using GridTariffApi.StartupTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Tests.StartupTasks
{
    public class SyncMeteringPointTariffStartupTaskTests
    {
        [Fact]
        public async Task ExecuteTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: "ExecuteTest"));

            var mockIMeteringPointTariffSynchronizer = new Mock<IMeteringPointTariffSynchronizer>();
            mockIMeteringPointTariffSynchronizer.Setup(x => x.SynchronizeMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<Company>(), It.IsAny<DateTimeOffset>())).Returns(Task.CompletedTask);

            services.AddSingleton<IMeteringPointTariffSynchronizer>(mockIMeteringPointTariffSynchronizer.Object);

            var serviceProvider = services.BuildServiceProvider();

            var mockSyncMeteringPointTariffStartupTask = new SyncMeteringPointTariffStartupTask(serviceProvider);
            await mockSyncMeteringPointTariffStartupTask.Execute();
            mockIMeteringPointTariffSynchronizer.Verify(x => x.SynchronizeMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<Company>(), It.IsAny<DateTimeOffset>()), Times.Once);
        }
    }
}
