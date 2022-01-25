using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public class TariffPriceCacheDataStore : ITariffPriceCacheDataStore
    {
        private readonly object _resetLockObject = new object();
        private TariffPriceStructureRoot _tariffPriceStructureRoot;
        private IReadOnlyList<Holiday> _holidayRoot;
        private Dictionary<string, MeteringPointTariff> _meteringPointTariffIndex;

        private DateTimeOffset _tariffCacheValidUntil = DateTime.UtcNow;

        public async Task<IReadOnlyList<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<String> meteringPoints, Func<List<string>, Task<IReadOnlyList<MeteringPointTariff>>> retrieveUncachedMeteringPointTariffsFunc)
        {
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
                var meteringPointTariffs = await retrieveUncachedMeteringPointTariffsFunc(uncachedMpids);
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

        public IReadOnlyList<Holiday> GetHolidayRoot()
        {
            if (_holidayRoot == null)
            {
                throw new TariffPriceCacheException("Attempt to access uninitialized holiday data from the cache");
            }

            return _holidayRoot;
        }

        public TariffPriceStructureRoot GetTariffRootElement()
        {
            if (_tariffPriceStructureRoot == null)
            {
                throw new TariffPriceCacheException("Attempt to access uninitialized tariff root data from the cache");
            }

            return _tariffPriceStructureRoot;
        }

        public void ResetCacheIfNecessary(ITariffRepository tariffRepository, IHolidayRepository holidayRepository)
        {
            lock(_resetLockObject)
            {
                if (_tariffCacheValidUntil.Ticks < DateTime.UtcNow.Ticks)
                {
                    _meteringPointTariffIndex = new Dictionary<string, MeteringPointTariff>(); // Reset caching of tariff per metering point. It is populated on demand.
                    _tariffPriceStructureRoot = tariffRepository.GetTariffPriceStructure();
                    _holidayRoot = holidayRepository.GetHolidays();
                    _tariffCacheValidUntil = DateTimeOffset.UtcNow.AddDays(1).Date;
                }
            }
        }
    }

    [Serializable]
    public class TariffPriceCacheException : Exception
    {
        public int HttpStatusCode { get; set; }
        
        public TariffPriceCacheException()
        {
        }

        public TariffPriceCacheException(string message)
            : base(message)
        {
        }

        public TariffPriceCacheException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected TariffPriceCacheException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
