using System.Collections.Generic;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class Season
    {
        public Season()
        {
            FixedPriceConfig = new HashSet<FixedPriceConfig>();
            VariablePriceConfig = new HashSet<VariablePriceConfig>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FixedPriceConfig> FixedPriceConfig { get; set; }
        public virtual ICollection<VariablePriceConfig> VariablePriceConfig { get; set; }
    }
}
