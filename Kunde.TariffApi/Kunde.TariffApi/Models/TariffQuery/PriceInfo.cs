using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.Models.TariffQuery
{
    public class PriceInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime ExpiredAt { get; set; }
        public String HoursShortName { get; set; }
        public String Season { get; set; }
        public bool PublicHoliday { get; set; }
        public List<FixedPrices> FixedPrices { get; set; }
        public VariablePrice VariablePrice { get; set; }
    }
}
