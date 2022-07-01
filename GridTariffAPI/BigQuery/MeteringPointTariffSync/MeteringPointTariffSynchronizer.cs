using Elvia.Telemetry;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using GridTariffApi.Database;
using GridTariffApi.Exceptions;
using GridTariffApi.Model;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
{
    public class MeteringPointTariffSynchronizer : CronJobService, IMeteringPointTariffSynchronizer
    {
        private readonly string _tableName = "MeteringPointTariff";
        private readonly int _elviaDbSyncChangesThreshold = 1000;
        private readonly string _elviaCompanyOrgNumber = "980489698";

        private readonly ITelemetryInsightsLogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public MeteringPointTariffSynchronizer(
            ITelemetryInsightsLogger logger,
            IScheduleConfig<MeteringPointTariffSynchronizer> config,
            IServiceProvider serviceProvider)
            : base(config.CronExpression, config.TimeZoneInfo, logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace($"{DisplayName}DoWorkStart: Starting synchronizing of meteringpoints with netproducts from Google BigQuery");
                using var scope = _serviceProvider.CreateScope();
                ElviaDbContext elviaDbContext = scope.ServiceProvider.GetRequiredService<ElviaDbContext>();
                var elviaCompany = elviaDbContext.Company.FirstOrDefault(x => x.OrgNumber == _elviaCompanyOrgNumber);
                var currentTimestamp = DateTimeOffset.UtcNow;
                var bigQueryReader = scope.ServiceProvider.GetRequiredService<IBigQueryReader>(); // Must create new BigQueryReader on each DoWork to avoid "Cannot access a disposed object. Object name: 'Google.Apis.Http.ConfigurableHttpClient'."
                await SynchronizeMeteringPointsAsync(elviaDbContext, bigQueryReader, elviaCompany, currentTimestamp);
                _logger.TrackTrace($"{DisplayName}DoWorkFinished: Done synchronizing of Meteringpoints with netproducts from Google BigQuery");
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public virtual async Task SynchronizeMeteringPointsAsync(ElviaDbContext elviaDbContext, IBigQueryReader bigQueryReader, Company elviaCompany, DateTimeOffset timeStamp)
        {
            var meteringPointTariffLastSynced = elviaDbContext.SyncStatus.FirstOrDefault(x => x.Table == _tableName);
            var fullSync = meteringPointTariffLastSynced == null;
            var stopwatch = Stopwatch.StartNew();
            _logger.TrackTrace($"{DisplayName}SynchronizeMeteringPointsAsyncStart", new {FullSync = fullSync, LastSynced = meteringPointTariffLastSynced});
            if (fullSync)
            {
                await MeteringPointTariffFullSync(elviaDbContext, bigQueryReader, timeStamp, elviaCompany);
                meteringPointTariffLastSynced = new SyncStatus()
                {
                    Table = _tableName,
                    LastUpdatedUtc = timeStamp,
                };
                elviaDbContext.SyncStatus.Add(meteringPointTariffLastSynced);
            }
            else
            {
                await SynchronizeMeteringPointsIncrementalAsync(elviaDbContext, bigQueryReader, meteringPointTariffLastSynced.LastUpdatedUtc, timeStamp, elviaCompany);
                meteringPointTariffLastSynced.LastUpdatedUtc = timeStamp;
            }
            _logger.TrackTrace($"{DisplayName}SynchronizeMeteringPointsAsyncPreSaveChanges", new {FullSync = fullSync, LastSynced = meteringPointTariffLastSynced, ElapsedSinceStart = stopwatch.Elapsed});
            await elviaDbContext.SaveChangesAsync();
            _logger.TrackTrace($"{DisplayName}SynchronizeMeteringPointsAsyncFinished", new {FullSync = fullSync, LastSynced = meteringPointTariffLastSynced, ElapsedSinceStart = stopwatch.Elapsed});
        }

        public virtual async Task MeteringPointTariffFullSync(ElviaDbContext elviaDbContext, IBigQueryReader bigQueryReader, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var result = await bigQueryReader.GetAllMeteringPointProductAsync();
            _logger.TrackTrace($"{DisplayName}MeteringPointTariffFullSyncAboutToInsert", new {NumUpdates = result.Count});
            try
            {
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await InsertMeteringPointsAsync(elviaDbContext, result, timeStamp, elviaCompany);
            }
            catch (Exception exception)
            {
                _logger.TrackException(new GridTariffApiException($"{DisplayName}MeteringPointTariffFullSyncFailed", exception));
            }
            finally
            {
                await elviaDbContext.SaveChangesAsync();
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public virtual async Task InsertMeteringPointsAsync(ElviaDbContext elviaDbContext, List<BigQueryMeteringPointProduct> meteringPoints, DateTimeOffset timeStamp, Company elviaCompany)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                elviaDbContext.MeteringPointTariff.Add(new MeteringPointTariff()
                {
                    MeteringPointId = element.MeteringPointId,
                    ProductKey = element.Product,
                    LastUpdatedUtc = timeStamp,
                    Company = elviaCompany
                });
                if (ctr++ % _elviaDbSyncChangesThreshold == 0)
                {
                    await elviaDbContext.SaveChangesAsync();
                }
            }
            await elviaDbContext.SaveChangesAsync();
        }

        public virtual async Task SynchronizeMeteringPointsIncrementalAsync(ElviaDbContext elviaDbContext, IBigQueryReader bigQueryReader, DateTimeOffset lastUpdated, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var result = await bigQueryReader.GetMeteringPointsByFromDateAsync(lastUpdated);
            _logger.TrackTrace($"{DisplayName}SynchronizeMeteringPointsIncrementalAsyncAboutToUpsert", new {NumUpdates = result.Count});
            await UpsertMeteringPointsAsync(elviaDbContext, result, timeStamp, elviaCompany);
        }

        public virtual async Task UpsertMeteringPointsAsync(ElviaDbContext elviaDbContext, List<BigQueryMeteringPointProduct> meteringPoints, DateTimeOffset timeStamp, Company elviaCompany)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                UpsertMeteringPointAsync(elviaDbContext, element, timeStamp, elviaCompany);
                if (ctr++ % _elviaDbSyncChangesThreshold == 0)
                {
                    await elviaDbContext.SaveChangesAsync();
                }
            }
            await elviaDbContext.SaveChangesAsync();
        }

        public void UpsertMeteringPointAsync(ElviaDbContext elviaDbContext, BigQueryMeteringPointProduct meteringPointProductBigQuery, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var entity = elviaDbContext.MeteringPointTariff.FirstOrDefault(x => x.MeteringPointId == meteringPointProductBigQuery.MeteringPointId);
            if (entity == null)
            {
                elviaDbContext.MeteringPointTariff.Add(new MeteringPointTariff()
                {
                    MeteringPointId = meteringPointProductBigQuery.MeteringPointId,
                    ProductKey = meteringPointProductBigQuery.Product,
                    LastUpdatedUtc = timeStamp,
                    Company = elviaCompany
                });
            }
            else
            {
                if (entity.ProductKey != meteringPointProductBigQuery.Product)
                {
                    entity.ProductKey = meteringPointProductBigQuery.Product;
                    entity.LastUpdatedUtc = timeStamp;
                }
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace($"{DisplayName}MeteringPointTariffSynchronizerStartAsync: Setting up scheduled synchronizing of meteringpoints with netproducts from Google BigQuery");
                return base.StartAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace($"{DisplayName}MeteringPointTariffSynchronizerStopAsync");
                return base.StopAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }
    }
}