using GridTariffApi.BigQuery.MeteringPointTariffSync;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using GridTariffApi.Database;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Tests.BigQuery.MeteringPointTariffSync
{
    public class MeteringPointTariffSynchronizerTests
    {
        private IServiceProvider? _serviceProvider;
        private ScheduleConfig<MeteringPointTariffSynchronizer>? _scheduleConfig;

        private void Setup()
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
        }
        [Fact]
        public async Task GetElviaCompanyTest()
        {
            Setup();
            string elviaCompanyName = "Elvia AS";
            string _elviaCompanyOrgNumber = "980489698";


            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.Company.FirstOrDefaultAsync());

            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await meteringPointTariffSynchronizer.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany);
            Assert.Equal(elviaCompanyName, elviaCompany.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());

            var elviaCompany2 = await meteringPointTariffSynchronizer.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany2);
            Assert.Equal(elviaCompanyName, elviaCompany2.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany2.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());
        }

        [Fact]
        public async Task InsertMeteringPointsAsyncTest()
        {
            Setup();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);

            var elviaCompany = await meteringPointTariffSynchronizer.GetElviaCompany(elviaDbContext);

            var input = new List<MeteringPointProductBigQuery>();
            input.Add(new MeteringPointProductBigQuery() { MeteringPointId = "a", Product = "x" });
            input.Add(new MeteringPointProductBigQuery() { MeteringPointId = "b", Product = "y" });

            var utcNow = DateTimeOffset.UtcNow;

            await meteringPointTariffSynchronizer.InsertMeteringPointsAsync(elviaDbContext,input,utcNow,elviaCompany);
            Assert.Equal(2, await elviaDbContext.MeteringPointTariff.CountAsync());
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync(x => x.MeteringPointId == "a" && x.ProductKey == "x" && x.LastUpdated == utcNow && x.Company == elviaCompany));
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync(x => x.MeteringPointId == "b" && x.ProductKey == "y" && x.LastUpdated == utcNow && x.Company == elviaCompany));

        }
        [Fact]
        public async Task UpsertMeteringPointAsyncTest()
        {
            Setup();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var utcNowInsert1 = DateTimeOffset.UtcNow;
            Thread.Sleep(1);
            var utcNowUpdate1 = DateTimeOffset.UtcNow;
            Thread.Sleep(1);
            var utcNowInsert2 = DateTimeOffset.UtcNow;
            var mpInsert1 = new MeteringPointProductBigQuery() { MeteringPointId = "mpA", Product = "prA" };
            var mpUpdate1 = new MeteringPointProductBigQuery() { MeteringPointId = "mpA", Product = "prB" };
            var mpInsert2 = new MeteringPointProductBigQuery() { MeteringPointId = "mpB", Product = "prC" };

//insert
            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await meteringPointTariffSynchronizer.GetElviaCompany(elviaDbContext);
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpInsert1, utcNowInsert1, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Single(elviaDbContext.MeteringPointTariff);
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpInsert1.MeteringPointId 
                && x.ProductKey == mpInsert1.Product && x.LastUpdated == utcNowInsert1 && x.Company == elviaCompany));

//update
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpUpdate1, utcNowUpdate1, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Single(elviaDbContext.MeteringPointTariff);
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpUpdate1.MeteringPointId 
                && x.ProductKey == mpUpdate1.Product && x.LastUpdated == utcNowUpdate1 && x.Company == elviaCompany));

//insert not touching existing data
            meteringPointTariffSynchronizer.UpsertMeteringPointAsync(elviaDbContext, mpInsert2, utcNowInsert2, elviaCompany);
            await elviaDbContext.SaveChangesAsync();
            Assert.Equal(2, await elviaDbContext.MeteringPointTariff.CountAsync());
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpUpdate1.MeteringPointId
                && x.ProductKey == mpUpdate1.Product && x.LastUpdated == utcNowUpdate1 && x.Company == elviaCompany));
            Assert.Equal(1, await elviaDbContext.MeteringPointTariff.CountAsync
                (x => x.MeteringPointId == mpInsert2.MeteringPointId
                && x.ProductKey == mpInsert2.Product && x.LastUpdated == utcNowInsert2 && x.Company == elviaCompany));
        }

        [Fact]
        public async Task UpsertMeteringPointsAsyncTest()
        {
            var numElementsToStore = 1234;
            Setup();
            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.MeteringPointTariff.FirstOrDefaultAsync());

            var meteringPoints = new List<MeteringPointProductBigQuery>();

            while (meteringPoints.Count < numElementsToStore)
            {
                meteringPoints.Add(new MeteringPointProductBigQuery() { MeteringPointId = System.Guid.NewGuid().ToString(), Product = System.Guid.NewGuid().ToString() });
            }

            var meteringPointTariffSynchronizer = new MeteringPointTariffSynchronizer(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await meteringPointTariffSynchronizer.GetElviaCompany(elviaDbContext);

            await meteringPointTariffSynchronizer.UpsertMeteringPointsAsync(elviaDbContext, meteringPoints, DateTimeOffset.UtcNow,elviaCompany);
            Assert.Equal(numElementsToStore, await elviaDbContext.MeteringPointTariff.CountAsync());
        }

        [Fact]
        public async Task SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsyncTest()
        {
            Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Empty(elviaDbContext.IntegrationConfig);

            var mockBigQueryReader = new Mock<GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader>();
            mockBigQueryReader.Setup(x => x.GetMeteringPointsByFromDateAsync(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(new List<MeteringPointProductBigQuery>()));

            var mockService = new Mock<MeteringPointTariffSynchronizer>(null, _scheduleConfig, _serviceProvider, mockBigQueryReader.Object);
            mockService.Setup(x => x.UpsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<MeteringPointProductBigQuery>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>())).Returns(Task.CompletedTask);
            mockService.CallBase = true;
            await mockService.Object.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(null, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, null);

            mockBigQueryReader.Verify(x => x.GetMeteringPointsByFromDateAsync(It.IsAny<DateTimeOffset>()), Times.Once);
            mockService.Verify(x => x.UpsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<MeteringPointProductBigQuery>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>()), Times.Once);
        }

        [Fact]
        public async Task MeteringPointTariffFullsyncTests()
        {
            Setup();
            var mockBigQueryReader = new Mock<GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader>();
            mockBigQueryReader.Setup(x => x.GetAllMeteringPointProductAsync()).Returns(Task.FromResult(new List<MeteringPointProductBigQuery>()));

            var mockService = new Mock<MeteringPointTariffSynchronizer>(null, _scheduleConfig, _serviceProvider, mockBigQueryReader.Object);
            mockService.Setup(x => x.InsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<MeteringPointProductBigQuery>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>())).Returns(Task.CompletedTask);
            mockService.CallBase = true;

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Empty(elviaDbContext.IntegrationConfig);

            var elviaCompany = await mockService.Object.GetElviaCompany(elviaDbContext);
            await mockService.Object.MeteringPointTariffFullSync(elviaDbContext, DateTimeOffset.UtcNow, elviaCompany);

            mockBigQueryReader.Verify(x => x.GetAllMeteringPointProductAsync(), Times.Once);
            mockService.Verify(x => x.InsertMeteringPointsAsync(It.IsAny<ElviaDbContext>(), It.IsAny<List<MeteringPointProductBigQuery>>(), It.IsAny<DateTimeOffset>(), It.IsAny<Model.Company>()), Times.Once);
        }

        [Fact]
        public async Task SynchronizeMeteringPointsAsyncInitialFullSyncTest()
        {
            Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            var mockService = new Mock<MeteringPointTariffSynchronizer>(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await mockService.Object.GetElviaCompany(elviaDbContext);
            var utcNow = DateTime.UtcNow;

            Assert.Empty(elviaDbContext.IntegrationConfig);

            mockService.Setup(x => x.MeteringPointTariffFullSync(It.IsAny<ElviaDbContext>(), utcNow, elviaCompany)).Returns(Task.CompletedTask);
            await mockService.Object.SynchronizeMeteringPointsAsync(elviaDbContext, elviaCompany, utcNow);

            mockService.Verify(x => x.MeteringPointTariffFullSync(It.IsAny<ElviaDbContext>(), utcNow, elviaCompany), Times.Once);
            Assert.Equal(1, elviaDbContext.IntegrationConfig.Count());
            var integrationConfig = elviaDbContext.IntegrationConfig.First();
            Assert.Equal("MeteringPointTariff", integrationConfig.Table);
            Assert.Equal(utcNow, integrationConfig.LastUpdated);

        }

        [Fact]
        public async Task SynchronizeMeteringPointsAsyncIncrementalSyncTest()
        {
            Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();

            Assert.Empty(elviaDbContext.IntegrationConfig);

            elviaDbContext.IntegrationConfig.Add(new Model.IntegrationConfig() { Table = "MeteringPointTariff", LastUpdated = DateTimeOffset.UtcNow });
            await elviaDbContext.SaveChangesAsync();

            Assert.Equal(1,elviaDbContext.IntegrationConfig.Count());

            var mockService = new Mock<MeteringPointTariffSynchronizer>(null, _scheduleConfig, _serviceProvider, null);
            var elviaCompany = await mockService.Object.GetElviaCompany(elviaDbContext);
            var utcNow = DateTimeOffset.UtcNow;
            mockService.Setup(x => x.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext, It.IsAny<DateTimeOffset>(), utcNow, elviaCompany)).Returns(Task.CompletedTask);

            await mockService.Object.SynchronizeMeteringPointsAsync(elviaDbContext, elviaCompany, utcNow);
            mockService.Verify(x => x.SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext, It.IsAny<DateTimeOffset>(), utcNow, elviaCompany), Times.Once);
            Assert.Equal(1, elviaDbContext.IntegrationConfig.Count());
            var integrationConfig = elviaDbContext.IntegrationConfig.First();
            Assert.Equal("MeteringPointTariff", integrationConfig.Table);
            Assert.Equal(utcNow, integrationConfig.LastUpdated);
        }
    }
}
