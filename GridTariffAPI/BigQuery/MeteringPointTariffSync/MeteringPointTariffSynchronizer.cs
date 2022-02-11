﻿using Elvia.Telemetry;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using GridTariffApi.Database;
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

        private async Task<Company> GetElviaCompany(ElviaDbContext elviaDbContext)
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
            var meteringPointTariffLastSynced = elviaDbContext.IntegrationConfig.FirstOrDefault(x => x.Table == _tableName);
            if (meteringPointTariffLastSynced == null)
            {
                await MeteringPointTariffFullsync(elviaDbContext,timeStamp, elviaCompany);
                meteringPointTariffLastSynced = new IntegrationConfig()
                {
                    Table = _tableName,
                    LastUpdated = timeStamp,
                };
                elviaDbContext.IntegrationConfig.Add(meteringPointTariffLastSynced);
            }
            else
            {
                await SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(elviaDbContext,meteringPointTariffLastSynced.LastUpdated,timeStamp,elviaCompany);
                meteringPointTariffLastSynced.LastUpdated = timeStamp;
            }
            await elviaDbContext.SaveChangesAsync();
        }

        private async Task MeteringPointTariffFullsync(ElviaDbContext elviaDbContext, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var result = await _bigQueryReader.GetAllMeteringPointProductAsync();
            try
            {
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await InsertMeteringPointsAsync(elviaDbContext,result, timeStamp, elviaCompany);
            }
            catch (Exception exception)
            {
                _logger.TrackException(exception);
            }
            finally
            {
                await elviaDbContext.SaveChangesAsync();
                elviaDbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        private async Task InsertMeteringPointsAsync(ElviaDbContext elviaDbContext, List<MeteringPointProductBigQuery> meteringPoints,DateTimeOffset timeStamp, Company elviaCompany)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                elviaDbContext.MeteringPointTariff.Add(new MeteringPointTariff()
                {
                    MeteringPointId = element.MeteringPointId,
                    ProductKey = element.Product,
                    LastUpdated = timeStamp,
                    Company = elviaCompany
                });
                if (ctr++ % _elviaDbSyncChangesThreshold == 0)
                {
                    await elviaDbContext.SaveChangesAsync();
                }
            }
            await elviaDbContext.SaveChangesAsync();
        }

        private async Task SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(ElviaDbContext elviaDbContext,DateTimeOffset lastUpdated,DateTimeOffset timeStamp,Company elviaCompany)
        {
            var result = _bigQueryReader.GetMeteringPointsByFromDateAsync(lastUpdated).Result;
            await UpsertMeteringPointsAsync(elviaDbContext,result, timeStamp, elviaCompany);
        }

        private async Task UpsertMeteringPointsAsync(ElviaDbContext elviaDbContext,List<MeteringPointProductBigQuery> meteringPoints,DateTimeOffset timeStamp, Company elviaCompany)
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

        private void UpsertMeteringPointAsync(ElviaDbContext elviaDbContext, MeteringPointProductBigQuery meteringPointProductBigQuery, DateTimeOffset timeStamp, Company elviaCompany)
        {
            var entity = elviaDbContext.MeteringPointTariff.FirstOrDefault(x => x.MeteringPointId == meteringPointProductBigQuery.MeteringPointId);
            if (entity == null)
            {
                elviaDbContext.MeteringPointTariff.Add(new MeteringPointTariff()
                {
                    MeteringPointId = meteringPointProductBigQuery.MeteringPointId,
                    ProductKey = meteringPointProductBigQuery.Product,
                    LastUpdated = timeStamp,
                    Company = elviaCompany
                });
            }
            else
            {
                if (entity.ProductKey != meteringPointProductBigQuery.Product)
                {
                    entity.ProductKey = meteringPointProductBigQuery.Product;
                    entity.LastUpdated = timeStamp;
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