using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            FixedPriceConfig = new HashSet<FixedPriceConfig>();
            VariablePriceConfig = new HashSet<VariablePriceConfig>();
        }

        public int Id { get; set; }
        public string Currency { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<FixedPriceConfig> FixedPriceConfig { get; set; }
        public virtual ICollection<VariablePriceConfig> VariablePriceConfig { get; set; }
    }
}
