﻿using Elvia.Telemetry;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Synchronizer.Lib.Config;
using GridTariffApi.Synchronizer.Lib.Model.BigQueryMeteringPoint;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public class GridTariffApiSynchronizer : IGridTariffApiSynchronizer
    {
        private readonly GridTariffApiSynchronizerConfig _gridTariffApiSynchronizerConfig;
        private readonly IBigQueryReader _bigQueryReader;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ITelemetryInsightsLogger _logger;

        private readonly int _dbSyncChangesThreshold = 100;
        private readonly string _fullSyncedMeteringPointProduct = "MeteringPointProductSync";

        public GridTariffApiSynchronizer(
            ITelemetryInsightsLogger logger,
            GridTariffApiSynchronizerConfig gridTariffAPISynchronizerConfig,
            IServiceScopeFactory serviceScopeFactory,
            IBigQueryReader bigQueryReader)
        {
            _logger = logger;
            _gridTariffApiSynchronizerConfig = gridTariffAPISynchronizerConfig;
            _serviceScopeFactory = serviceScopeFactory;
            _bigQueryReader = bigQueryReader;
        }

        public async Task SynchronizeMeteringPointsAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TariffContext>();
                var meteringPointSyncConfig = dbContext.IntegrationConfigs.FirstOrDefault(x => x.TableUpdated.Equals(_fullSyncedMeteringPointProduct));
                if (meteringPointSyncConfig == null)
                {
                    await SynchronizeMeteringSynchronizeMeteringPointsFullAsync(dbContext);
                    dbContext.Add(new IntegrationConfig()
                    {
                        TableUpdated = _fullSyncedMeteringPointProduct,
                        UpdatedDate = DateTime.UtcNow
                    });
                }
                else
                {
                    await SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(dbContext, meteringPointSyncConfig.UpdatedDate);
                    meteringPointSyncConfig.UpdatedDate = DateTime.UtcNow;
                }
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task SynchronizeMeteringSynchronizeMeteringPointsFullAsync(TariffContext dbContext)
        {
            List<ProductTariffMapping> tariffMappings = dbContext.ProductTariffMappings.ToList();
            var result = await _bigQueryReader.GetAllMeteringPointProductAsync();
            try
            {
                dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await InsertMeteringPointsAsync(result, dbContext, tariffMappings);
            }
            catch (Exception exception)
            {
                _logger.TrackException(exception);
            }
            finally
            {
                await dbContext.SaveChangesAsync();
                dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
        private async Task SynchronizeMeteringSynchronizeMeteringPointsIncrementalAsync(TariffContext dbContext, DateTime fromDate)
        {
            List<ProductTariffMapping> tariffMappings = dbContext.ProductTariffMappings.ToList();
            var result = _bigQueryReader.GetMeteringPointsByFromDateAsync(fromDate).Result;
            await UpsertMeteringPointsAsync(dbContext, result, tariffMappings);
        }

        private async Task UpsertMeteringPointsAsync(TariffContext dbContext, List<BqMeteringPointProduct> meteringPoints, List<ProductTariffMapping> tariffMappings)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                await UpsertMeteringPointAsync(dbContext, element, tariffMappings);
                if (ctr++ % _dbSyncChangesThreshold == 0)
                {
                    await dbContext.SaveChangesAsync();
                }
            }
            await dbContext.SaveChangesAsync();
        }

        private async Task UpsertMeteringPointAsync(TariffContext dbContext, BqMeteringPointProduct bqMeteringPoint, List<ProductTariffMapping> tariffMappings)
        {
            var tariffMapping = tariffMappings.FirstOrDefault(t => t.NetProduct.Equals(bqMeteringPoint.Product));
            if (tariffMapping != null)
            {
                var entity = dbContext.MeteringPointProducts.FirstOrDefault(m => m.MeteringpointId.Equals(bqMeteringPoint.MeteringPointId));
                if (entity == null)
                {
                    await InsertMeteringPointAsync(bqMeteringPoint, dbContext, tariffMapping.Tariffkey);
                }
                else if (!entity.Product.Equals(tariffMapping.NetProduct)
                    || !entity.TariffKey.Equals(tariffMapping.Tariffkey)
                    || entity.AreaCode != bqMeteringPoint.Area)
                {
                    entity.Product = tariffMapping.NetProduct;
                    entity.TariffKey = tariffMapping.Tariffkey;
                    entity.AreaCode = bqMeteringPoint.Area;
                    entity.LastUpdatedDate = DateTime.UtcNow;
                }
            }
        }

        private async Task InsertMeteringPointsAsync(List<BqMeteringPointProduct> meteringPoints, TariffContext dbContext, List<ProductTariffMapping> tariffMappings)
        {
            int ctr = 0;
            foreach (var element in meteringPoints)
            {
                var tariffMapping = tariffMappings.FirstOrDefault(t => t.NetProduct.Equals(element.Product));
                if (tariffMapping != null)
                {
                    await InsertMeteringPointAsync(element, dbContext, tariffMapping.Tariffkey);
                }
                if (ctr++ % _dbSyncChangesThreshold == 0)
                {
                    dbContext.SaveChanges();
                }
            }
            await dbContext.SaveChangesAsync();
        }

        private async Task InsertMeteringPointAsync(BqMeteringPointProduct element, TariffContext dbContext, string tariffKey)
        {
            await dbContext.AddAsync(
                new MeteringPointProduct()
                {
                    MeteringpointId = element.MeteringPointId,
                    Product = element.Product,
                    AreaCode = element.Area,
                    LastUpdatedDate = DateTime.UtcNow,
                    TariffKey = tariffKey
                });
        }
    }
}
