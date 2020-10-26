using System;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Variablepriceconfig
    {
        public int Id { get; set; }
        public int Tarifftypeid { get; set; }
        public int Seasonid { get; set; }
        public int Monthno { get; set; }
        public int Pricelevelid { get; set; }
        public decimal Total { get; set; }
        public decimal Energy { get; set; }
        public decimal Power { get; set; }
        public decimal Taxmva { get; set; }
        public decimal Taxenova { get; set; }
        public decimal Taxenergy { get; set; }
        public int Uomid { get; set; }
        public DateTime Pricefromdate { get; set; }
        public DateTime Pricetodate { get; set; }
        public string Hours { get; set; }

        public virtual Pricelevel Pricelevel { get; set; }
        public virtual Season Season { get; set; }
        public virtual Tarifftype Tarifftype { get; set; }
        public virtual UnitofMeasure Uom { get; set; }
    }
}
