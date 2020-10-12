using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Tarifftype
    {
        public Tarifftype()
        {
            Fixedpriceconfig = new HashSet<Fixedpriceconfig>();
            Variablepriceconfig = new HashSet<Variablepriceconfig>();
        }

        public int Id { get; set; }
        public string Tariffkey { get; set; }
        public int Companyid { get; set; }
        public string Customertype { get; set; }
        public string Title { get; set; }
        public int Resolution { get; set; }
        public string Description { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Fixedpriceconfig> Fixedpriceconfig { get; set; }
        public virtual ICollection<Variablepriceconfig> Variablepriceconfig { get; set; }
    }
}
