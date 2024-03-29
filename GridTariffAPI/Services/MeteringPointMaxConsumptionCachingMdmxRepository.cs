﻿using System;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Mdmx;
using GridTariffApi.Metrics;
using Microsoft.Extensions.Caching.Memory;
using GridTariffApi.Lib.Services.Helpers;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionCachingMdmxRepository : IMeteringPointMaxConsumptionRepository
    {
        private readonly IMdmxClient _mdmxClient;
        private readonly MeteringPointMaxConsumptionRepositoryConfig _config;
        private readonly IElviaLoggingDataCollector _loggingDataCollector;
        private readonly IServiceHelper _serviceHelper;

        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());

        public MeteringPointMaxConsumptionCachingMdmxRepository(IMdmxClient mdmxClient, 
            MeteringPointMaxConsumptionRepositoryConfig config,
            IServiceHelper serviceHelper,
            IElviaLoggingDataCollector loggingDataCollector = null)
        {
            _mdmxClient = mdmxClient;
            _config = config;
            _loggingDataCollector = loggingDataCollector;
            _serviceHelper = serviceHelper;
        }

        public async Task<List<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(
            DateTimeOffset fromDateTime, 
            DateTimeOffset toDateTime, 
            List<string> meteringPointIds)
        {
            bool isFetchMaxConsumption = _serviceHelper.TimePeriodIsIncludingLocaleToday(fromDateTime, toDateTime);
            if (!isFetchMaxConsumption)
            {
                    return meteringPointIds.Select(mpid => new MeteringPointMaxConsumption { MeteringPointId = mpid }).ToList();
            }

            var cachedMaxConsumptions = new Dictionary<string, MeteringPointMaxConsumption>();
            var uncachedMpids = new List<string>();

            foreach (var mpid in meteringPointIds)
            {
                if (MemoryCache.TryGetValue(mpid, out MeteringPointMaxConsumption cachedMaxConsumption))
                {
                    cachedMaxConsumptions[mpid] = cachedMaxConsumption;
                }
                else
                {
                    uncachedMpids.Add(mpid);
                }
            }

            _loggingDataCollector?.RegisterMaxConsumptionCacheHitStatistics(cachedMaxConsumptions.Count, uncachedMpids.Count);

            if (uncachedMpids.Count > 0)
            {
                // There is a possible race condition here, so we might consider doing another lookup after locking. But an additional cache miss on parallel calls for the same metering point(s) is not that important. And the last one will update the cache.
                var uncachedMaxConsumptions = await _mdmxClient.GetMaxConsumptionsAsync(meteringPointIds);

                lock (MemoryCache)
                {
                    foreach (var meteringPointMaxConsumption in uncachedMaxConsumptions)
                    {
                        MemoryCache.Set(meteringPointMaxConsumption.MeteringPointId, meteringPointMaxConsumption, _config.MaxConsumptionCacheTimeout);
                        cachedMaxConsumptions[meteringPointMaxConsumption.MeteringPointId] = meteringPointMaxConsumption;
                    }
                }
            }

            return meteringPointIds.Select(mpid => cachedMaxConsumptions[mpid]).ToList();
        }
    }
}