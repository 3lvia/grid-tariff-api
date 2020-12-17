using System.Collections.Generic;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class FixedPriceLevel
    {
        public FixedPriceLevel()
        {
            FixedPriceConfig = new HashSet<FixedPriceConfig>();
        }

        public int Id { get; set; }
        public string PriceLevel { get; set; }
        public string LevelInfo { get; set; }

        public virtual ICollection<FixedPriceConfig> FixedPriceConfig { get; set; }
    }
}
