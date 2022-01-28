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

        public async Task<List<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<string> meteringPoints, Func<List<string>, Task<IReadOnlyList<MeteringPointTariff>>> retrieveUncachedMeteringPointTariffsFunc)
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
                .ToList();
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

        public async Task ResetCacheIfNecessaryAsync(ITariffRepository tariffRepository, IHolidayRepository holidayRepository)
        {
            if (_tariffCacheValidUntil.Ticks > DateTime.UtcNow.Ticks)
            {
                return;
            }

            // Fetch data if the cache is no longer valid. Avoid doing async operations within lock statement.
            var tariffPriceStructureRoot = await tariffRepository.GetTariffPriceStructureAsync();
            var holidayRoot = await holidayRepository.GetHolidaysAsync();

            // Update the cache unless someone else has done it while we were fetching data.
            lock(_resetLockObject)
            {
                if (_tariffCacheValidUntil.Ticks < DateTime.UtcNow.Ticks)
                {
                    _meteringPointTariffIndex = new Dictionary<string, MeteringPointTariff>(); // Reset caching of tariff per metering point. It is populated on demand.
                    _tariffPriceStructureRoot = tariffPriceStructureRoot;
                    _holidayRoot = holidayRoot;
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
