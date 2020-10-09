using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Uom
    {
        public Uom()
        {
            Variablepriceconfig = new HashSet<Variablepriceconfig>();
        }

        public int Id { get; set; }
        public string Currency { get; set; }
        public string Uom1 { get; set; }

        public virtual ICollection<Variablepriceconfig> Variablepriceconfig { get; set; }
    }
}
