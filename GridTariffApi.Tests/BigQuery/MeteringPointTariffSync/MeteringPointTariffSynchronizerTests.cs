using GridTariffApi.BigQuery.MeteringPointTariffSync;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using GridTariffApi.Database;
using GridTariffApi.StartupTasks;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elvia.Telemetry;
using Xunit;

namespace GridTariffApi.Tests.BigQuery.MeteringPointTariffSync
{
    public class MeteringPointTariffSynchronizerTests
    {
        private IServiceProvider? _serviceProvider;
        private ScheduleConfig<MeteringPointTariffSynchronizer>? _scheduleConfig;

        private async Task  Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            services.AddCronJob<MeteringPointTariffSynchronizer>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"0 6 * * *";      //every day at
            });

            _serviceProvider = services.BuildServiceProvider();
            _scheduleConfig = new ScheduleConfig<MeteringPointTariffSynchronizer>() { CronExpression = @"0 6 * * *" };

            var prepDatabase = new PrepareDatabaseStartupTask(_serviceProvider);
            await prepDatabase.Execute();

        }

        [Fact]
        public async Task InsertMeteringPointsAsyncTest()
        {
            await Setup();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);

            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();

            var input = new List<BigQueryMeteringPointProduct>
            {
                new BigQueryMeteringPointProduct() { MeteringPointId = "a", Product = "x" },
                new BigQueryMeteringPointProduct() { MeteringPointId = "b", Product = "y" }
            };

            var utcNow = DateTimeOffset.UtcNow;

            await meteringPointTariffSynchronizer.InsertMeteringPointsAsync(elviaDbContext,input,utcNow,elviaCompany);
            Assert.Equal(2, await elviaDbContext.MeteringPointTariff.CountAsync());
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync(x => x.MeteringPointId == "a" && x.ProductKey == "x" && x.LastUpdatedUtc == utcNow && x.Company == elviaCompany));
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync(x => x.MeteringPointId == "b" && x.ProductKey == "y" && x.LastUpdatedUtc == utcNow && x.Company == elviaCompany));

        }
        [Fact]
        public async Task UpsertMeteringPointAsyncTest()
        {
            await Setup();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var utcNowInsert1 = DateTimeOffset.UtcNow;
            Thread.Sleep(1);
            var utcNowUpdate1 = DateTimeOffset.UtcNow;
            Thread.Sleep(1);
            var utcNowInsert2 = DateTimeOffset.UtcNow;
            var mpInsert1 = new BigQueryMeteringPointProduct() { MeteringPointId = "mpA", Product = "prA" };
            var mpUpdate1 = new BigQueryMeteringPointProduct() { MeteringPointId = "mpA", Product = "prB" };
            var mpInsert2 = new BigQueryMeteringPointProduct() { MeteringPointId = "mpB", Product = "prC" };

//insert
            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpInsert1, utcNowInsert1, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Single(elviaDbContext.MeteringPointTariff);
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpInsert1.MeteringPointId 
                && x.ProductKey == mpInsert1.Product && x.LastUpdatedUtc == utcNowInsert1 && x.Company == elviaCompany));

//update
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpUpdate1, utcNowUpdate1, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Single(elviaDbContext.MeteringPointTariff);
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpUpdate1.MeteringPointId 
                && x.ProductKey == mpUpdate1.Product && x.LastUpdatedUtc == utcNowUpdate1 && x.Company == elviaCompany));

//insert not touching existing data
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpInsert2, utcNowInsert2, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Equal(2, await elviaDbContext.MeteringPointTariff.CountAsync());
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpUpdate1.MeteringPointId
                && x.ProductKey == mpUpdate1.Product && x.LastUpdatedUtc == utcNowUpdate1 && x.Company == elviaCompany));
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpInsert2.MeteringPointId
                && x.ProductKey == mpInsert2.Product && x.LastUpdatedUtc == utcNowInsert2 && x.Company == elviaCompany));
        }

        [Fact]
        public async Task UpsertMeteringPointsAsyncTest()
        {
            var numElementsToStore = 1234;
            await Setup ();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var meteringPoints = new List<BigQueryMeteringPointProduct>();

            while (meteringPoints.Count < numElementsToStore)
            {
                meteringPoints.Add(new BigQueryMeteringPointProduct() { MeteringPointId = System.Guid.NewGuid().ToString(), Product = System.Guid.NewGuid().ToString() });
            }

            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();

            await meteringPointTariffSynchronizer.UpsertMeteringPointsAsync(elviaDbContext, meteringPoints, DateTimeOffset.UtcNow,elviaCompany);
            Assert.Equal(numElementsToStore, await elviaDbContext.MeteringPointTariff.CountAsync());
        }

        [Fact]
        public async Task SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsyncTest()
        {
            await Setup ();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Empty(elviaDbContext.SyncStatus);

            var mockBigQueryReader = new Mock<GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader>();
            mockBigQueryReader.Setup(x => x.GetMeteringPointsByFromDateAsync(It.IsAny<DateTimeOffset>())).ReturnsAsync(new List<BigQueryMeteringPointProduct>());

            var mockService = new Mock<MeteringPointTariffSynchronizer>(new Mock<ITelemetryInsightsLogger>().Object, _scheduleConfig, _serviceProvider, mockBigQueryReader.Object);
            mockService.Setup(x => x.UpsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<BigQueryMeteringPointProduct>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>())).Returns(Task.CompletedTask);
            mockService.CallBase = true;
            await mockService.Object.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(null, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, null);

            mockBigQueryReader.Verify(x => x.GetMeteringPointsByFromDateAsync(It.IsAny<DateTimeOffset>()), Times.Once);
            mockService.Verify(x => x.UpsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<BigQueryMeteringPointProduct>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>()), Times.Once);
        }

        [Fact]
        public async Task MeteringPointTariffFullsyncTests()
        {
            await Setup();
            var mockBigQueryReader = new Mock<GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader>();
            mockBigQueryReader.Setup(x => x.GetAllMeteringPointProductAsync()).ReturnsAsync(new List<BigQueryMeteringPointProduct>());

            var mockService = new Mock<MeteringPointTariffSynchronizer>(new Mock<ITelemetryInsightsLogger>().Object, _scheduleConfig, _serviceProvider, mockBigQueryReader.Object);
            mockService.Setup(x => x.InsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<BigQueryMeteringPointProduct>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>())).Returns(Task.CompletedTask);
            mockService.CallBase = true;

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Empty(elviaDbContext.SyncStatus);

            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();
            await mockService.Object.MeteringPointTariffFullSync(elviaDbContext, DateTimeOffset.UtcNow, elviaCompany);

            mockBigQueryReader.Verify(x => x.GetAllMeteringPointProductAsync(), Times.Once);
            mockService.Verify(x => x.InsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<BigQueryMeteringPointProduct>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>()), Times.Once);
        }

        [Fact]
        public async Task SynchronizeMeteringPointsAsyncInitialFullSyncTest()
        {
            await Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            var mockService = new Mock<MeteringPointTariffSynchronizer>(new Mock<ITelemetryInsightsLogger>().Object, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();
            var utcNow = DateTime.UtcNow;

            Assert.Empty(elviaDbContext.SyncStatus);

            mockService.Setup(x => x.MeteringPointTariffFullSync(It.IsAny<ElviaDbContext>(), utcNow, elviaCompany)).Returns(Task.CompletedTask);
            mockService.CallBase = true;
            await mockService.Object.SynchronizeMeteringPointsAsync(elviaDbContext, elviaCompany, utcNow);

            mockService.Verify(x => x.MeteringPointTariffFullSync(It.IsAny<ElviaDbContext>(), utcNow, elviaCompany), Times.Once);
            Assert.Equal(1, elviaDbContext.SyncStatus.Count());
            var syncStatus = elviaDbContext.SyncStatus.First();
            Assert.Equal("MeteringPointTariff", syncStatus.Table);
            Assert.Equal(utcNow, syncStatus.LastUpdatedUtc);

        }

        [Fact]
        public async Task SynchronizeMeteringPointsAsyncIncrementalSyncTest()
        {
            await Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();

            Assert.Empty(elviaDbContext.SyncStatus);

            elviaDbContext.SyncStatus.Add(new Model.SyncStatus() { Table = "MeteringPointTariff", LastUpdatedUtc = DateTimeOffset.UtcNow });
            await elviaDbContext.SaveChangesAsync();

            Assert.Equal(1,elviaDbContext.SyncStatus.Count());

            var mockService = new Mock<MeteringPointTariffSynchronizer>(new Mock<ITelemetryInsightsLogger>().Object, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await elviaDbContext.Company.FirstOrDefaultAsync();
            var utcNow = DateTimeOffset.UtcNow;
            mockService.Setup(x => x.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext, It.IsAny<DateTimeOffset>(), utcNow, elviaCompany)).Returns(Task.CompletedTask);
            mockService.CallBase = true;

            await mockService.Object.SynchronizeMeteringPointsAsync(elviaDbContext, elviaCompany, utcNow);
            mockService.Verify(x => x.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext, It.IsAny<DateTimeOffset>(), utcNow, elviaCompany), Times.Once);
            Assert.Equal(1, elviaDbContext.SyncStatus.Count());
            var syncStatus = elviaDbContext.SyncStatus.First();
            Assert.Equal("MeteringPointTariff", syncStatus.Table);
            Assert.Equal(utcNow, syncStatus.LastUpdatedUtc);
        }
    }
}
