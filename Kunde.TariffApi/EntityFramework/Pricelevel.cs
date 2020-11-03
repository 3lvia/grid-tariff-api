﻿using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Pricelevel
    {
        public Pricelevel()
        {
            Variablepriceconfig = new HashSet<Variablepriceconfig>();
        }

        public int Id { get; set; }
        public int Sortorder { get; set; }
        public string PricelevelDescription { get; set; }

        public virtual ICollection<Variablepriceconfig> Variablepriceconfig { get; set; }
    }
}