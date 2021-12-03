using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GridTariffApi.Lib.Services.V2
{
    public interface ITariffPriceCache
    {
        Models.V2.PriceStructure.Company GetCompany();
        Models.V2.PriceStructure.TariffType GetTariff(String tariffKey);
        IReadOnlyList<Models.V2.PriceStructure.TariffType> GetTariffs();

        List<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate);
    }

    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffPersistence _tariffPersistence;
        private readonly IHolidayPersistence _holidayPersistence;

        private static TariffPriceStructureRoot _tariffPriceStructureRoot;
        private static List<Holiday> _holidayRoot;

        private static DateTime _cacheValidUntil = DateTime.UtcNow;
        private static SemaphoreSlim _lockSemaphore = new SemaphoreSlim(1);
        public TariffPriceCache(ITariffPersistence tariffPersistence
            , IHolidayPersistence holidayPersistence)
        {
            _tariffPersistence = tariffPersistence;
            _holidayPersistence = holidayPersistence;
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

        public List<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            GetTariffRootElement(); //refresh cache
            return _holidayRoot.Where(a => a.Date >= fromDate && a.Date <= toDate).ToList();
        }

        private TariffPriceStructureRoot GetTariffRootElement()
        {
            try
            {
                _lockSemaphore.Wait();
                if (_cacheValidUntil.Ticks < DateTime.UtcNow.Ticks)
                {
                    RefreshCache();
                }
            }
            catch (Exception e)
            {
                //todo tracktrace exception
                _lockSemaphore.Release();

            }
            finally
            {
                _lockSemaphore.Release();
            }
            return _tariffPriceStructureRoot;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2696:Instance members should not write to \"static\" fields", Justification = "Performed inside semaphore")]
        private void RefreshCache()
        {
            _tariffPriceStructureRoot = _tariffPersistence.GetTariffPriceStructure();
            _holidayRoot = _holidayPersistence.GetHolidays();
        }
    }
}
