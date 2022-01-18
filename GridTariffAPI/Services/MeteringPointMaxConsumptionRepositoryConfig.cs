using System;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionRepositoryConfig
    {
        public TimeZoneInfo TimeZoneForMonthLimiting { get; set; }
        /// <summary>
        /// MaxConsumption is cached per meteringPoint. It should not be cached for a long time, as that could mask a current/recent increase in MaxConsumption.
        /// However, it is usually calculated once per hour, and often not calculated instantly at the end of each hour.
        /// So caching for a shorter amount of time has little or no impact on the result, and may have a great impact on performance on parallell/subsequent calls for the same meteringPointId.
        /// </summary>
        public TimeSpan MaxConsumptionCacheTimeout { get; set; }
    }
}
