using GridTariffApi.Lib.Interfaces.V2.External;
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
        Models.V2.PriceStructure.TariffType GetTariff(String tariffKey, DateTimeOffset fromDate, DateTimeOffset toDate);
        List<Models.V2.PriceStructure.TariffType> GetTariffs();
    }

    public class TariffPriceCache : ITariffPriceCache
    {
        private readonly ITariffPersistence _tariffPersistence;
        private static TariffPriceStructureRoot _tariffPriceStructureRoot;
        private static DateTime _cacheValidUntil = DateTime.UtcNow;
        private static SemaphoreSlim _lockSemaphore = new SemaphoreSlim(1);
        public TariffPriceCache(ITariffPersistence tariffPersistence)
        {
            _tariffPersistence = tariffPersistence;
        }

        public Models.V2.PriceStructure.Company GetCompany()
        {
            return GetRootElement().GridTariffPriceConfiguration.GridTariff.Company;

        }

        public List<Models.V2.PriceStructure.TariffType> GetTariffs()
        {
            var tariffPriceStructureRoot = GetRootElement();
            return tariffPriceStructureRoot.GridTariffPriceConfiguration.GridTariff.TariffTypes;
        }


        public Models.V2.PriceStructure.TariffType GetTariff(String tariffKey, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var tariffPriceStructureRoot = GetRootElement();
            var retVal = tariffPriceStructureRoot.GridTariffPriceConfiguration.GridTariff.TariffTypes.FirstOrDefault(a => a.TariffKey == tariffKey);
            if (retVal != null)
            {
                retVal.TariffPrices.RemoveAll(a => a.StartDate > toDate || a.EndDate < fromDate);
            }
            return retVal;
        }

        private TariffPriceStructureRoot GetRootElement()
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
        }
    }
}
