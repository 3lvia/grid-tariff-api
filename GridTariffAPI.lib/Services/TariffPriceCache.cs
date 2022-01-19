using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffPriceCacheDataStore _cacheDataStore;
        private readonly ITariffRepository _tariffRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMeteringPointTariffRepository _meteringPointTariffRepository;
        private readonly IMeteringPointMaxConsumptionRepository _meteringPointMaxConsumptionRepository;

        public TariffPriceCache(ITariffPriceCacheDataStore cacheDataStore,
            ITariffRepository tariffRepository,
            IHolidayRepository holidayRepository,
            IMeteringPointTariffRepository meteringPointTariffRepository, 
            IMeteringPointMaxConsumptionRepository meteringPointMaxConsumptionRepository)
        {
            _cacheDataStore = cacheDataStore;
            _tariffRepository = tariffRepository;
            _holidayRepository = holidayRepository;
            _meteringPointTariffRepository = meteringPointTariffRepository;
            _meteringPointMaxConsumptionRepository = meteringPointMaxConsumptionRepository;
            // The cache data store is a singleton, to be able to cache between calls. It cannot consume scoped services. So the TariffPriceCache calls ResetCacheIfNecessary to keep the cache fresh.
            _cacheDataStore.ResetCacheIfNecessary(_tariffRepository, _holidayRepository);
        }

        public  async Task<List<MeteringPointInformation>> GetMeteringPointInformationsAsync(DateTimeOffset fromDateTime, DateTimeOffset toDateTime, List<string> meteringPoints)
        {
            // We combine MeteringPointTariffs and MeteringPointMaxConsumptions (separate caching and data sources) into one MeteringPointInformation per metering point.

            var resDict = new Dictionary<string, MeteringPointInformation>();

            var mpMaxConsumptionsTask = _meteringPointMaxConsumptionRepository.GetMeteringPointMaxConsumptionsAsync(fromDateTime, toDateTime, meteringPoints);

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
            _cacheDataStore.ResetCacheIfNecessary(_tariffRepository, _holidayRepository);

            return await _cacheDataStore.GetMeteringPointTariffsAsync(meteringPoints, uncachedMpids => _meteringPointTariffRepository.GetMeteringPointTariffsAsync(uncachedMpids));
        }

        public Models.PriceStructure.Company GetCompany()
        {
            return GetTariffRootElement().GridTariffPriceConfiguration.GridTariff.Company;
        }

        public IReadOnlyList<Models.PriceStructure.TariffType> GetTariffs()
        {
            return GetTariffRootElement().GridTariffPriceConfiguration.GridTariff.TariffTypes;
        }


        public Models.PriceStructure.TariffType GetTariff(String tariffKey)
        {
            var retVal = GetTariffRootElement().GridTariffPriceConfiguration.GridTariff.TariffTypes.FirstOrDefault(a => a.TariffKey == tariffKey);
            return retVal;
        }

        public IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            _cacheDataStore.ResetCacheIfNecessary(_tariffRepository, _holidayRepository);
            
            return _cacheDataStore.GetHolidayRoot().Where(a => a.Date >= fromDate && a.Date <= toDate).ToList();
        }
        
        public TariffPriceStructureRoot GetTariffRootElement()
        {
            _cacheDataStore.ResetCacheIfNecessary(_tariffRepository, _holidayRepository);
            
            return _cacheDataStore.GetTariffRootElement();
        }
    }
}
