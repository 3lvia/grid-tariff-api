using Elvia.Telemetry;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Synchronizer.Lib.Config;
using GridTariffApi.Synchronizer.Lib.Model.BigQueryMeteringPoint;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Synchronizer.Lib.Tests.Services
{
    public class GridTariffApiSynchronizerTests
    {
        private Mock<IBigQueryReader> _mockBigQueryReader;
        private Mock<IServiceScopeFactory> _mockServiceScopeFactory;
        private IServiceProvider _serviceProvider;
        private Mock<ITelemetryInsightsLogger> _mocklogger;


        private readonly string _fullSyncedMeteringPointProduct = "MeteringPointProductSync";
        private void Init()
        {
            _mockBigQueryReader = new Mock<IBigQueryReader>();
            _mockBigQueryReader
                .Setup(w => w.GetAllMeteringPointProductAsync())
                .Returns(GenerateBigQueryResults());

            _mockBigQueryReader
                .Setup(w => w.GetMeteringPointsByFromDateAsync(It.IsAny<DateTime>()))
                .Returns(GenerateBigQueryResults());

            var services = new ServiceCollection();
            services.AddDbContext<TariffContext>(u => u.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            _serviceProvider = services.BuildServiceProvider();

            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(_serviceProvider);

            _mockServiceScopeFactory = new Mock<IServiceScopeFactory>();
            _mockServiceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            _mocklogger = new Mock<ITelemetryInsightsLogger>();

            GenerateProductMapping(_serviceProvider);
        }

        [Fact()]
        public async Task FullSyncTest()
        {
            Init();

            var dbContext = _serviceProvider.GetRequiredService<TariffContext>();
            var gridTariffApiSynchronizer = new GridTariffApiSynchronizer(_mocklogger.Object, _mockServiceScopeFactory.Object, _mockBigQueryReader.Object);
            await gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            VerifyDbContent(dbContext);
        }

        [Fact()]
        public async Task IncrementalInsertTest()
        {
            Init();

            var dbContext = _serviceProvider.GetRequiredService<TariffContext>();
            dbContext.IntegrationConfigs.Add(new IntegrationConfig()
            {
                TableUpdated = _fullSyncedMeteringPointProduct,
                UpdatedDate = DateTime.UtcNow
            });

            var gridTariffApiSynchronizer = new GridTariffApiSynchronizer(_mocklogger.Object, _mockServiceScopeFactory.Object, _mockBigQueryReader.Object);
            await gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            VerifyDbContent(dbContext);
        }

        [Fact()]
        public async Task IncrementalUpsertNetProductTest()
        {
            Init();

            var dbContext = _serviceProvider.GetRequiredService<TariffContext>();
            AddMeteringPointProductToDatabase(dbContext, "mp1", "bogus", "GridTariff1", 0, DateTime.UtcNow);
            AddIntegrationConfig(dbContext);

            var gridTariffApiSynchronizer = new GridTariffApiSynchronizer(_mocklogger.Object, _mockServiceScopeFactory.Object, _mockBigQueryReader.Object);
            await gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            VerifyDbContent(dbContext);
        }

        private void AddIntegrationConfig(TariffContext dbContext)
        {
            dbContext.IntegrationConfigs.Add(new IntegrationConfig()
            {
                TableUpdated = _fullSyncedMeteringPointProduct,
                UpdatedDate = DateTime.UtcNow
            });
            dbContext.SaveChanges();
        }

        [Fact()]
        public async Task IncrementalUpsertAreaTest()
        {
            Init();

            var dbContext = _serviceProvider.GetRequiredService<TariffContext>();
            AddMeteringPointProductToDatabase(dbContext, "mp1", "HN ELHA avr", "GridTariff1", 100, DateTime.UtcNow);
            AddIntegrationConfig(dbContext);

            var gridTariffApiSynchronizer = new GridTariffApiSynchronizer(_mocklogger.Object, _mockServiceScopeFactory.Object, _mockBigQueryReader.Object);
            await gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            VerifyDbContent(dbContext);
        }

        [Fact()]
        public async Task IncrementalUpsertTariffTest()
        {
            Init();

            var dbContext = _serviceProvider.GetRequiredService<TariffContext>();
            AddMeteringPointProductToDatabase(dbContext, "mp1", "HN ELHA avr", "Bogus", 0, DateTime.UtcNow);
            AddIntegrationConfig(dbContext);

            var gridTariffApiSynchronizer = new GridTariffApiSynchronizer(_mocklogger.Object, _mockServiceScopeFactory.Object, _mockBigQueryReader.Object);
            await gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            VerifyDbContent(dbContext);
        }

        private static void AddMeteringPointProductToDatabase(TariffContext dbContext, string meteringPointId, string product, string tariffKey, int areacode, DateTime lastUpdatedDate)
        {
            dbContext.MeteringPointProducts.Add(new MeteringPointProduct()
            {
                MeteringpointId = meteringPointId,
                Product = product,
                TariffKey = tariffKey,
                AreaCode = areacode,
                LastUpdatedDate = lastUpdatedDate
            });
            dbContext.SaveChanges();
        }

        private static void GenerateProductMapping(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<TariffContext>();
            AddProductTariffMapping(dbContext, "HN ELHA avr", "GridTariff1");
            AddProductTariffMapping(dbContext, "E10", "GridTariff2");
        }

        private async Task<List<BqMeteringPointProduct>> GenerateBigQueryResults()
        {
            await Task.CompletedTask;
            return new List<BqMeteringPointProduct>()
            {
                CreateBqMeteringPointProduct("mp1","HN ELHA avr",0),
                CreateBqMeteringPointProduct("mp2","E10",1),
                CreateBqMeteringPointProduct("miss","Miss",1)
            };
        }
        private static void AddProductTariffMapping(TariffContext dbContext, string netProduct, string tariffKey)
        {
            dbContext.Add(new ProductTariffMapping()
            {
                NetProduct = netProduct,
                Tariffkey = tariffKey,
                Created = DateTime.UtcNow,
                Lastupdated = DateTime.UtcNow
            });
            dbContext.SaveChanges();
        }

        BqMeteringPointProduct CreateBqMeteringPointProduct(string meteringPointId, string product, int area)
        {
            return new BqMeteringPointProduct()
            {
                MeteringPointId = meteringPointId,
                Product = product,
                Area = area
            };
        }
        private static void VerifyDbContent(TariffContext dbContext)
        {
            var integrationConfig = dbContext.IntegrationConfigs.FirstOrDefault();
            Assert.NotNull(integrationConfig);
            Assert.Equal("MeteringPointProductSync", integrationConfig.TableUpdated);
            Assert.True(DateTime.UtcNow > integrationConfig.UpdatedDate);

            var meteringPointProducts = dbContext.MeteringPointProducts.ToList();
            Assert.Equal(2, meteringPointProducts.Count);

            var mp1 = meteringPointProducts.FirstOrDefault(x => x.MeteringpointId.Equals("mp1"));
            Assert.NotNull(mp1);
            Assert.Equal("HN ELHA avr", mp1.Product);
            Assert.Equal(0, mp1.AreaCode);
            Assert.Equal("GridTariff1", mp1.TariffKey);
            Assert.True(DateTime.UtcNow > mp1.LastUpdatedDate);

            var mp2 = meteringPointProducts.FirstOrDefault(x => x.MeteringpointId.Equals("mp2"));
            Assert.NotNull(mp2);
            Assert.Equal("E10", mp2.Product);
            Assert.Equal(1, mp2.AreaCode);
            Assert.Equal("GridTariff2", mp2.TariffKey);
            Assert.True(DateTime.UtcNow > mp2.LastUpdatedDate);
        }
    }
}
