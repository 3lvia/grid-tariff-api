using System;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Mdmx;
using GridTariffApi.Metrics;
using Microsoft.Extensions.Caching.Memory;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionCachingMdmxRepository : IMeteringPointMaxConsumptionRepository
    {
        private readonly IMdmxClient _mdmxClient;
        private readonly MeteringPointMaxConsumptionRepositoryConfig _config;
        private readonly IElviaLoggingDataCollector _loggingDataCollector;

        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());

        public MeteringPointMaxConsumptionCachingMdmxRepository(IMdmxClient mdmxClient, MeteringPointMaxConsumptionRepositoryConfig config, IElviaLoggingDataCollector loggingDataCollector = null)
        {
            _mdmxClient = mdmxClient;
            _config = config;
            _loggingDataCollector = loggingDataCollector;
        }

        public async Task<IReadOnlyList<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(DateTimeOffset fromDateTime, DateTimeOffset toDateTime, List<string> meteringPointIds)
        {
            if (!MaxConsumptionIsValidForPeriod(fromDateTime, toDateTime))
            {
                return meteringPointIds.Select(mpid => new MeteringPointMaxConsumption { MeteringPointId = mpid }).ToList().AsReadOnly();
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
                var uncachedMaxConsumptions = await _mdmxClient.GetVolumeAggregationsForThisMonthAsync(meteringPointIds);

                lock (MemoryCache)
                {
                    foreach (var meteringPointMaxConsumption in uncachedMaxConsumptions)
                    {
                        MemoryCache.Set(meteringPointMaxConsumption.MeteringPointId, meteringPointMaxConsumption, _config.MaxConsumptionCacheTimeout);
                        cachedMaxConsumptions[meteringPointMaxConsumption.MeteringPointId] = meteringPointMaxConsumption;
                    }
                }
            }

            return meteringPointIds.Select(mpid => cachedMaxConsumptions[mpid]).ToList().AsReadOnly();
        }

        public bool MaxConsumptionIsValidForPeriod(DateTimeOffset fromDateTime, DateTimeOffset toDateTime)
        {
            // If any part of the current month is included in the period, we'll return the maxConsumption if we have it. If not, we consider it not valid for the period.
            // Note: we use "today" when connecting metering points to fixed prices. So in practice, we don't need this "current month" check. But it is a logical part of the max consumption interface.
            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _config.TimeZoneForMonthLimiting);
            var localMonthStart = new DateTime(localNow.Year, localNow.Month, 1, 0, 0, 0, localNow.Kind);
            var localMiddleOfNextMonth = localMonthStart.AddDays(30 + 15);
            var localMonthEnd = new DateTime(localMiddleOfNextMonth.Year, localMiddleOfNextMonth.Month, 1, 0, 0, 0, localNow.Kind);
            // TODO: move month/period handling to helper methods

            if (fromDateTime >= localMonthEnd)
            {
                return false;
            }

            if (toDateTime <= localMonthStart)
            {
                return false;
            }

            return true;
        }
    }
}