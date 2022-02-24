using System;

namespace GridTariffApi.Lib.Config
{
    public class GridTariffApiConfig
    {
        public DateTime MinStartDateAllowedQuery { get; set; }
        public TimeZoneInfo TimeZoneForQueries { get; set; }
    }
}
