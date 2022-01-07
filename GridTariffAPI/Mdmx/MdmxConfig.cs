using System;

namespace GridTariffApi.Mdmx
{
    public class MdmxConfig
    {
        public string HostAddress { get; set; }
        public TimeZoneInfo TimeZoneForMonthLimiting { get; set; }
    }
}
