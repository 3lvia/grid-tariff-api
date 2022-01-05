using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.Internal;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GridTariffApi.Lib.Services.V2
{
    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffRepository _tariffRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMeteringPointRepository _meteringPointTariffRepository;

        private TariffPriceStructureRoot _tariffPriceStructureRoot;
        private IReadOnlyList<Holiday> _holidayRoot;
        private readonly Dictionary<string, MeteringPointInformation> _meteringPointIndex;

        private DateTime _tariffCacheValidUntil = DateTime.UtcNow;
        public TariffPriceCache(ITariffRepository tariffRepository
            , IHolidayRepository holidayRepository,
            IMeteringPointRepository meteringPointTariffRepository)
        {
            _tariffRepository = tariffRepository;
            _holidayRepository = holidayRepository;
            _meteringPointTariffRepository = meteringPointTariffRepository;
            _meteringPointIndex = new Dictionary<string, MeteringPointInformation>();
            RefreshCache();
        }

        public List<MeteringPointInformation> GetMeteringPointInformation(List<String> meteringPoints)
        {
            var retVal = _meteringPointIndex.Where(a => meteringPoints.Contains(a.Key)).Select(a => a.Value).ToList();
            if (retVal.Count < meteringPoints.Count)
            {
                var missingMeteringPoints = meteringPoints.Where(x => !retVal.Any(a => a.MeteringPointId == x)).ToList();
                retVal.AddRange(IndexMeteringPoints(missingMeteringPoints));
            }
            return retVal;
        }

        public List<MeteringPointInformation> IndexMeteringPoints(List<String> meteringPoints)
        {
            var retVal = new List<MeteringPointInformation>();
            lock (_meteringPointIndex)
            {
                var meteringPointsInformation = _meteringPointTariffRepository.GetMeteringPointsInformation(meteringPoints);
                foreach (var meterinPoint in meteringPointsInformation)
                {
                    _meteringPointIndex.Add(meterinPoint.MeteringPointId, meterinPoint);
                    retVal.Add(meterinPoint);
                }
            }
            return retVal;
        }


        public Models.V2.PriceStructure.Company GetCompany()
        {
            return GetTariffRootElement().GridTariffPriceConfiguration.GridTariff.Company;
        }

        public IReadOnlyList<Models.V2.PriceStructure.TariffType> GetTariffs()
        {
            var tariffPriceStructureRoot = GetTariffRootElement();
            return tariffPriceStructureRoot.GridTariffPriceConfiguration.GridTariff.TariffTypes;
        }


        public Models.V2.PriceStructure.TariffType GetTariff(String tariffKey)
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
            _tariffCacheValidUntil = DateTime.UtcNow.AddMinutes(Constants.CacheConsideredInvalidMinutes).Date;
        }
    }
}
