using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Fixedpricelevel
    {
        public Fixedpricelevel()
        {
            Fixedpriceconfig = new HashSet<Fixedpriceconfig>();
        }

        public int Id { get; set; }
        public string Pricelevel { get; set; }
        public string Levelinfo { get; set; }

        public virtual ICollection<Fixedpriceconfig> Fixedpriceconfig { get; set; }
    }
}
