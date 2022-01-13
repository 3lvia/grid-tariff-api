using System;

namespace GridTariffApi.Lib.Config
{
    public class GridTariffApiConfig
    {
        public string DBConnectionString { get; set; }
        public string InstrumentationKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime MinStartDateAllowedQuery { get; set; }
        public TimeZoneInfo TimeZoneForQueries { get; set; }
        /// <summary>
        /// MaxConsumption is cached per meteringPoint. It should not be cached for a long time, as that could mask a current/recent increase in MaxConsumption.
        /// However, it is usually calculated once per hour, and often not calculated instantly at the end of each hour.
        /// So caching for a shorter amount of time has little or no impact on the result, and may have a great impact on performance on parallell/subsequent calls for the same meteringPointId.
        /// </summary>
        public TimeSpan MaxConsumptionCacheTimeout { get; set; }
    }
}
