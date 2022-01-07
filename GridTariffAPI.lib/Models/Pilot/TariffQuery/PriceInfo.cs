using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.Pilot.TariffQuery
{
    public class PriceInfo
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }
        public String HoursShortName { get; set; }
        public String Season { get; set; }
        public bool PublicHoliday { get; set; }
        public List<FixedPrices> FixedPrices { get; set; }
        public VariablePrice VariablePrice { get; set; }
    }
}
