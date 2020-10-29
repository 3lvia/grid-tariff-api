﻿using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class UnitofMeasure
    {
        public UnitofMeasure()
        {
            Fixedpriceconfig = new HashSet<Fixedpriceconfig>();
            Variablepriceconfig = new HashSet<Variablepriceconfig>();
        }

        public int Id { get; set; }
        public string Currency { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<Fixedpriceconfig> Fixedpriceconfig { get; set; }
        public virtual ICollection<Variablepriceconfig> Variablepriceconfig { get; set; }
    }
}
