using System.Collections.Generic;

namespace Kunde.TariffApi.Models.TariffQuery
{
    public class GridTariff
    {
        public TariffType TariffType { get; set; }
        public List<TariffPrices> TariffPrices { get; set; }
    }
}
