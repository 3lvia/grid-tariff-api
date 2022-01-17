using System;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Lib.Config;
using GridTariffApi.Mdmx;
using Microsoft.Extensions.Caching.Memory;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionCachingRepository : IMeteringPointMaxConsumptionRepository
    {
        private readonly IMeteringPointMaxConsumptionRepository _uncachedRepository;
        private readonly GridTariffApiConfig _config;
        private readonly IMemoryCache _memoryCache;

        public MeteringPointMaxConsumptionCachingRepository(IMdmxClient mdmxClient, GridTariffApiConfig config)
        {
            _config = config;
            _uncachedRepository = new MeteringPointMaxConsumptionMdmxRepository(mdmxClient);
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
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
                if (_memoryCache.TryGetValue(mpid, out MeteringPointMaxConsumption cachedMaxConsumption))
                {
                    cachedMaxConsumptions[mpid] = cachedMaxConsumption;
                }
                else
                {
                    uncachedMpids.Add(mpid);
                }
            }

            if (uncachedMpids.Count > 0)
            {
                // There is a possible race condition here, so we might consider doing another lookup after locking. But an additional cache miss on parallel calls for the same metering point(s) is not that important. And the last one will update the cache.
                var uncachedMaxConsumptions = await _uncachedRepository.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, uncachedMpids);

                lock (_memoryCache)
                {
                    foreach (var meteringPointMaxConsumption in uncachedMaxConsumptions)
                    {
                        _memoryCache.Set(meteringPointMaxConsumption.MeteringPointId, meteringPointMaxConsumption, _config.MaxConsumptionCacheTimeout);
                        cachedMaxConsumptions[meteringPointMaxConsumption.MeteringPointId] = meteringPointMaxConsumption;
                    }
                }
            }

            return meteringPointIds.Select(mpid => cachedMaxConsumptions[mpid]).ToList().AsReadOnly();
        }

        public bool MaxConsumptionIsValidForPeriod(DateTimeOffset fromDateTime, DateTimeOffset toDateTime)
        {
            // If any part of "today" is included in the period, we'll apply the maxConsumption if we have it. If not, we consider it not valid for the period.
            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _config.TimeZoneForQueries);
            var localTodayStart = (DateTimeOffset)new DateTime(localNow.Date.Ticks);
            var localTodayEnd = localTodayStart.AddDays(1);

            if (fromDateTime > localTodayEnd)
            {
                return false;
            }

            if (toDateTime < localTodayStart)
            {
                return false;
            }

            return true;
        }
    }
}