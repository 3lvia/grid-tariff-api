﻿using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace GridTariffApi.Lib.Services
{
    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffRepository _tariffRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMeteringPointTariffRepository _meteringPointTariffRepository;
        private readonly IMeteringPointMaxConsumptionRepository _meteringPointMaxConsumptionRepository;

        private TariffPriceStructureRoot _tariffPriceStructureRoot;
        private IReadOnlyList<Holiday> _holidayRoot;
        private readonly Dictionary<string, MeteringPointTariff> _meteringPointTariffIndex;
        private readonly IMemoryCache _meteringPointMaxConsumptionMemoryCache;

        private DateTime _tariffCacheValidUntil = DateTime.UtcNow;
        public TariffPriceCache(ITariffRepository tariffRepository
            , IHolidayRepository holidayRepository,
            IMeteringPointTariffRepository meteringPointTariffRepository, IMeteringPointMaxConsumptionRepository meteringPointMaxConsumptionRepository)
        {
            _tariffRepository = tariffRepository;
            _holidayRepository = holidayRepository;
            _meteringPointTariffRepository = meteringPointTariffRepository;
            _meteringPointMaxConsumptionRepository = meteringPointMaxConsumptionRepository;
            _meteringPointMaxConsumptionMemoryCache = new MemoryCache(new MemoryCacheOptions());
            _meteringPointTariffIndex = new Dictionary<string, MeteringPointTariff>();
            RefreshCache();
        }

        public List<MeteringPointInformation> GetMeteringPointInformation(List<String> meteringPoints)
        {
            // TODO: Gjøre denne metoden (public interface-metode) async. Midlertidig sync-to-async-hack:
            return GetMeteringPointInformationAsync(meteringPoints).Result;
        }

        private async Task<List<MeteringPointInformation>> GetMeteringPointInformationAsync(List<String> meteringPoints)
        {
            // We combine MeteringPointTariffs and MeteringPointMaxConsumptions (separate caching and data sources) into one MeteringPointInformation per metering point.

            var resDict = new Dictionary<string, MeteringPointInformation>();

            var mpMaxConsumptionsTask = GetMeteringPointMaxConsumptionsAsync(meteringPoints);

            var mpTariffs = await GetMeteringPointTariffsAsync(meteringPoints);
            foreach (var mpTariff in mpTariffs)
            {
                resDict[mpTariff.MeteringPointId] = new MeteringPointInformation(mpTariff.MeteringPointId, mpTariff.TariffKey, null, null);
            }

            var mpMaxConsumptions = await mpMaxConsumptionsTask;
            foreach (var mpMaxConsumption in mpMaxConsumptions)
            {
                var mpInfo = resDict[mpMaxConsumption.MeteringPointId];
                mpInfo.MaxConsumption = mpMaxConsumption.MaxHourlyEnergyConsumption;
                mpInfo.MaxConsumptionLastUpdated = mpMaxConsumption.LastVolumeEndTime;
            }

            return resDict.Values.ToList();
        }


        public async Task<IReadOnlyList<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<String> meteringPoints)
        {
            // TODO: oppdatering av MeteringPointTariffs-cache'n. Jobb på siden som oppdaterer hele cachen hver døgn?
            var cachedMpTariffs = new Dictionary<string, MeteringPointTariff>();
            var uncachedMpids = new List<string>();

            foreach (var mpid in meteringPoints)
            {

                if (_meteringPointTariffIndex.TryGetValue(mpid, out MeteringPointTariff cachedMpTariff))
                {
                    cachedMpTariffs[mpid] = cachedMpTariff;
                }
                else
                {
                    uncachedMpids.Add(mpid);
                }
            }

            if (uncachedMpids.Count > 0)
            {
                var meteringPointTariffs = await _meteringPointTariffRepository.GetMeteringPointTariffsAsync(uncachedMpids);
                lock (_meteringPointTariffIndex)
                {
                    foreach (var meteringPointTariff in meteringPointTariffs)
                    {
                        _meteringPointTariffIndex[meteringPointTariff.MeteringPointId] = meteringPointTariff;
                        cachedMpTariffs[meteringPointTariff.MeteringPointId] = meteringPointTariff;
                    }
                }
            }

            return meteringPoints
                .Select(mpid =>
                {
                    cachedMpTariffs.TryGetValue(mpid, out var cachedMpTariff);
                    return cachedMpTariff ?? new MeteringPointTariff(mpid, null);
                })
                .ToList()
                .AsReadOnly();
        }

        public async Task<IReadOnlyList<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(List<String> meteringPoints)
        {
            var cachedMaxConsumptions = new Dictionary<string, MeteringPointMaxConsumption>();
            var uncachedMpids = new List<string>();

            foreach (var mpid in meteringPoints)
            {
                if (_meteringPointMaxConsumptionMemoryCache.TryGetValue(mpid, out MeteringPointMaxConsumption cachedMaxConsumption))
                {
                    cachedMaxConsumptions[mpid] = cachedMaxConsumption;
                }
                else
                {
                    uncachedMpids.Add(mpid);
                }
            }

            if(uncachedMpids.Count > 0)
            {
                // There is a possible race condition here, so we might consider doing another lookup after locking. But an additional cache miss on parallel calls for the same metering point(s) is not that important. And the last one will update the cache.
                var uncachedMaxConsumptions = await _meteringPointMaxConsumptionRepository.GetMeteringPointMaxConsumptionsAsync(uncachedMpids);

                lock (_meteringPointMaxConsumptionMemoryCache)
                {
                    foreach (var meteringPointMaxConsumption in uncachedMaxConsumptions)
                    {
                        _meteringPointMaxConsumptionMemoryCache.Set(meteringPointMaxConsumption.MeteringPointId, meteringPointMaxConsumption, TimeSpan.FromHours(1)); // TODO: sette timeout (fra config utenfor Lib)
                        cachedMaxConsumptions[meteringPointMaxConsumption.MeteringPointId] = meteringPointMaxConsumption;
                    }
                }
            }

            return meteringPoints.Select(mpid => cachedMaxConsumptions[mpid]).ToList().AsReadOnly();
        }
        
        public Models.PriceStructure.Company GetCompany()
        {
            return GetTariffRootElement().GridTariffPriceConfiguration.GridTariff.Company;
        }

        public IReadOnlyList<Models.PriceStructure.TariffType> GetTariffs()
        {
            var tariffPriceStructureRoot = GetTariffRootElement();
            return tariffPriceStructureRoot.GridTariffPriceConfiguration.GridTariff.TariffTypes;
        }


        public Models.PriceStructure.TariffType GetTariff(String tariffKey)
        {
            var tariffPriceStructureRoot = GetTariffRootElement();
            var retVal = tariffPriceStructureRoot.GridTariffPriceConfiguration.GridTariff.TariffTypes.FirstOrDefault(a => a.TariffKey == tariffKey);
            return retVal;
        }

        public IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            GetTariffRootElement(); //refresh cache
            return _holidayRoot.Where(a => a.Date >= fromDate && a.Date <= toDate).ToList();
        }

        public TariffPriceStructureRoot GetTariffRootElement()
        {
            lock(_tariffPriceStructureRoot)
            {
                if (_tariffCacheValidUntil.Ticks < DateTime.UtcNow.Ticks)
                {
                    RefreshCache();
                }

            }
            return _tariffPriceStructureRoot;
        }

        private void RefreshCache()
        {
            _tariffPriceStructureRoot = _tariffRepository.GetTariffPriceStructure();
            _holidayRoot = _holidayRepository.GetHolidays();
            _tariffCacheValidUntil = DateTime.UtcNow.AddMinutes(Constants.CacheConsideredInvalidMinutes).Date; // TODO: endre logikk eller navngiving. Virker merkelig å angi cache-levetiden i minutter, sette den til 24*60 og så trunkere til midnatt. Og dette gjelder jo bare prislistedelen av cachen, ikke per-målepunkt-delen.
        }
    }
}
