using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class TariffType
    {
        public TariffType()
        {
            FixedPriceConfig = new HashSet<FixedPriceConfig>();
            VariablePriceConfig = new HashSet<VariablePriceConfig>();
        }

        public int Id { get; set; }
        public string TariffKey { get; set; }
        public int CompanyId { get; set; }
        public string CustomerType { get; set; }
        public string Title { get; set; }
        public int Resolution { get; set; }
        public string Description { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<FixedPriceConfig> FixedPriceConfig { get; set; }
        public virtual ICollection<VariablePriceConfig> VariablePriceConfig { get; set; }
    }
}
