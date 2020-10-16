using System;

namespace Kunde.TariffApi.Models.TariffQuery
{
    public class TariffQueryRequest
    {
        public String? TariffKey { get; set; }
        public String? Range { get; set; }       //todo really needed ?
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
