using System;
using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Fixedpriceconfig
    {
        public int Id { get; set; }
        public int Tarifftypeid { get; set; }
        public int Seasonid { get; set; }
        public int Monthno { get; set; }
        public int Pricelevelid { get; set; }
        public decimal Total { get; set; }
        public decimal Fixed { get; set; }
        public decimal Taxes { get; set; }
        public int Uomid { get; set; }
        public DateTime Pricefromdate { get; set; }
        public DateTime Pricetodate { get; set; }

        public virtual Fixedpricelevel Pricelevel { get; set; }
        public virtual Season Season { get; set; }
        public virtual Tarifftype Tarifftype { get; set; }
        public virtual Uom Uom { get; set; }
    }
}
