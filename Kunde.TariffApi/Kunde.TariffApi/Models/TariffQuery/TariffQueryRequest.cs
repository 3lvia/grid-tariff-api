using System;

namespace Kunde.TariffApi.Models.TariffQuery
{
    public class TariffQueryRequest
    {
#nullable enable
        public String? TariffKey { get; set; }
        public String? Range { get; set; }
#nullable disable
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
