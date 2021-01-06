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
    }
}
