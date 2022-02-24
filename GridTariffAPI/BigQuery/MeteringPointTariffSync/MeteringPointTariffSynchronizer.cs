﻿using Elvia.Telemetry;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using GridTariffApi.Database;
using GridTariffApi.Exceptions;
using GridTariffApi.Model;
using GridTariffApi.Synchronizer.Lib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
{
    public class MeteringPointTariffSynchronizer : CronJobService
    {
        private readonly string _tableName = "MeteringPointTariff";
        private readonly int _elviaDbSyncChangesThreshold = 1000;
        private readonly string _elviaCompanyName = "Elvia AS";
        private readonly string _elviaCompanyOrgNumber = "980489698";

        private readonly ITelemetryInsightsLogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader _bigQueryReader;

        public MeteringPointTariffSynchronizer(
            ITelemetryInsightsLogger logger,
            IScheduleConfig<MeteringPointTariffSynchronizer> config,
            IServiceProvider serviceProvider,
            GridTariffApi.BigQuery.MeteringPointTariffSync.IBigQueryReader bigQueryReader)
            : base(config.CronExpression, config.TimeZoneInfo, logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _bigQueryReader = bigQueryReader;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace("Starting synchronizing of meteringpoints with netproducts from Google BigQuery");
                using var scope = _serviceProvider.CreateScope();
                ElviaDbContext elviaDbContext = scope.ServiceProvider.GetRequiredService<ElviaDbContext>();
                var elviaCompany = await GetElviaCompany(elviaDbContext);
                var currentTimestamp = DateTimeOffset.UtcNow;
                await SynchronizeMeteringPointsAsync(elviaDbContext,elviaCompany, currentTimestamp);
                _logger.TrackTrace("Done synchronizing of Meteringpoints with netproducts from Google BigQuery");
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public async Task<Company> GetElviaCompany(ElviaDbContext elviaDbContext)
        {
            var elviaCompany = elviaDbContext.Company.FirstOrDefault(x => x.OrgNumber == _elviaCompanyOrgNumber);
            if (elviaCompany == null)
            {
                elviaCompany = new Company()
                {
                    OrgNumber = _elviaCompanyOrgNumber,
                    Name = _elviaCompanyName
                };
                elviaDbContext.Company.Add(elviaCompany);
                await elviaDbContext.SaveChangesAsync();
            }
            return elviaCompany;
        }
        public async Task SynchronizeMeteringPointsAsync(ElviaDbContext elviaDbContext, Company elviaCompany, DateTimeOffset timeStamp)
        {
            var meteringPointTariffLastSynced = elviaDbContext.SyncStatus.FirstOrDefault(x => x.Table == _tableName);
            if (meteringPointTariffLastSynced == null)
            {
                await MeteringPointTariffFullSync(elviaDbContext,timeStamp, elviaCompany);
                meteringPointTariffLastSynced = new SyncStatus()
                {
                    Table = _tableName,
                    LastUpdatedUtc = timeStamp,
                };
                elviaDbContext.SyncStatus.Add(meteringPointTariffLastSynced);
            }
            else
            {
                await SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext,meteringPointTariffLastSynced.LastUpdatedUtc,timeStamp,elviaCompany);
                meteringPointTariffLastSynced.LastUpdatedUtc = timeStamp;
            }
            await elviaDbContext.SaveChangesAsync();
        }

        public virtual async Task MeteringPointTariffFullSync(ElviaDbContext elviaDbContext, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var result = await _bigQueryReader.GetAllMeteringPointProductAsync();
            try
            {
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await InsertMeteringPointsAsync(elviaDbContext,result, timeStamp, elviaCompany);
            }
            catch (Exception exception)
            {
                _logger.TrackException(new GridTariffApiException("MeteringPointTariffFullSync failed", exception));
            }
            finally
            {
                await elviaDbContext.SaveChangesAsync();
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public virtual async Task InsertMeteringPointsAsync(ElviaDbContext elviaDbContext, List<BigQueryMeteringPointProduct> meteringPoints,DateTimeOffset timeStamp, Company elviaCompany)
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

        public virtual async Task SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(ElviaDbContext elviaDbContext,DateTimeOffset lastUpdated,DateTimeOffset timeStamp,Company elviaCompany)
        {
            var result = await _bigQueryReader.GetMeteringPointsByFromDateAsync(lastUpdated);
            await UpsertMeteringPointsAsync(elviaDbContext,result, timeStamp, elviaCompany);
        }

        public virtual async Task UpsertMeteringPointsAsync(ElviaDbContext elviaDbContext,List<BigQueryMeteringPointProduct> meteringPoints,DateTimeOffset timeStamp, Company elviaCompany)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                UpsertMeteringPointAsync(elviaDbContext,element, timeStamp, elviaCompany);
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
                _logger.TrackTrace("Setting up scheduled synchronizing of meteringpoints with netproducts from Google BigQuery");
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
                _logger.TrackTrace("Failed synchronizing of meteringpoints with netproducts from Google BigQuery");
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
