using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Season
    {
        public Season()
        {
            Variablepriceconfig = new HashSet<Variablepriceconfig>();
        }

        public int Id { get; set; }
        public string Season1 { get; set; }

        public virtual ICollection<Variablepriceconfig> Variablepriceconfig { get; set; }
    }
}
