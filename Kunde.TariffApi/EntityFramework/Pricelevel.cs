using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class PriceLevel
    {
        public PriceLevel()
        {
            VariablePriceConfig = new HashSet<VariablePriceConfig>();
        }

        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string PriceLevelDescription { get; set; }

        public virtual ICollection<VariablePriceConfig> VariablePriceConfig { get; set; }
    }
}
