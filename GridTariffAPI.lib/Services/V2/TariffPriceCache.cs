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
    public interface ITariffPriceCache
    {
        Models.V2.PriceStructure.Company GetCompany();
        Models.V2.PriceStructure.TariffType GetTariff(String tariffKey);
        IReadOnlyList<Models.V2.PriceStructure.TariffType> GetTariffs();
        IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate);
        List<MeteringPointInformation> GetMeteringPointInformation(List<String> meteringPoints);
    }

    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffPersistence _tariffPersistence;
        private readonly IHolidayPersistence _holidayPersistence;
        private readonly IMeteringPointPersistence _meteringPointTariffPersistence;

        private TariffPriceStructureRoot _tariffPriceStructureRoot;
        private IReadOnlyList<Holiday> _holidayRoot;
        private readonly Dictionary<string, MeteringPointInformation> _meteringPointIndex;

        private  DateTime _cacheValidUntil = DateTime.UtcNow;
        private readonly SemaphoreSlim _tariffLockSemaphore = new SemaphoreSlim(1);
        private readonly SemaphoreSlim _meteringPointLockSemaphore = new SemaphoreSlim(1);
        public TariffPriceCache(ITariffPersistence tariffPersistence
            , IHolidayPersistence holidayPersistence,
            IMeteringPointPersistence meteringPointTariffPersistence)
        {
            _tariffPersistence = tariffPersistence;
            _holidayPersistence = holidayPersistence;
            _meteringPointTariffPersistence = meteringPointTariffPersistence;
            _meteringPointIndex = new Dictionary<string, MeteringPointInformation>();
        }

        public List<MeteringPointInformation> GetMeteringPointInformation(List<String> meteringPoints)
        {
            var distinctMeteringPoints = meteringPoints.Distinct().ToList();
            var retVal = _meteringPointIndex.Where(a => distinctMeteringPoints.Contains(a.Key)).Select(a => a.Value).ToList();
            if (retVal.Count < distinctMeteringPoints.Count)
            {
                var missingMeteringPoints = distinctMeteringPoints.Where(x => !retVal.Any(a => a.MeteringPointId == x)).ToList();
                IndexMeteringPoints(missingMeteringPoints);
                retVal.AddRange(_meteringPointIndex.Where(a => missingMeteringPoints.Contains(a.Key)).Select(a => a.Value));
            }
            return retVal;
        }

        public void IndexMeteringPoints(List<String> meteringPoints)
        {
            try
            {
                _meteringPointLockSemaphore.Wait();
                var meteringPointsInformation = _meteringPointTariffPersistence.GetMeteringPointsInformation(meteringPoints);
                foreach (var meterinPoint in meteringPointsInformation)
                {
                    _meteringPointIndex.Add(meterinPoint.MeteringPointId, meterinPoint);
                }
            }
            catch (Exception)
            {
                _meteringPointLockSemaphore.Release();
                throw;
            }
            finally
            {
                _meteringPointLockSemaphore.Release();
            }
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
            try
            {
                _tariffLockSemaphore.Wait();
                if (_cacheValidUntil.Ticks < DateTime.UtcNow.Ticks)
                {
                    RefreshCache();
                }
            }
            catch (Exception)
            {
                _tariffLockSemaphore.Release();
                throw;

            }
            finally
            {
                _tariffLockSemaphore.Release();
            }
            return _tariffPriceStructureRoot;
        }

        private void RefreshCache()
        {
            _tariffPriceStructureRoot = _tariffPersistence.GetTariffPriceStructure();
            _holidayRoot = _holidayPersistence.GetHolidays();
            _cacheValidUntil = DateTime.UtcNow.AddMinutes(Constants.CacheConsideredInvalidMinutes).Date;
        }
    }
}
