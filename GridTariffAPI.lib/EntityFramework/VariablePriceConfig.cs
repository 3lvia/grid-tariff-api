using System;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class VariablePriceConfig
    {
        public int Id { get; set; }
        public int TariffTypeDd { get; set; }
        public int SeasonId { get; set; }
        public int MonthNo { get; set; }
        public int PriceLevelId { get; set; }
        public decimal Total { get; set; }
        public decimal Energy { get; set; }
        public decimal Power { get; set; }
        public decimal TaxMva { get; set; }
        public decimal TaxEnova { get; set; }
        public decimal TaxEnergy { get; set; }
        public int UomId { get; set; }
        public DateTime PriceFromDate { get; set; }
        public DateTime PriceToDate { get; set; }
        public string Hours { get; set; }

        public virtual PriceLevel PriceLevel { get; set; }
        public virtual Season Season { get; set; }
        public virtual TariffType TariffType { get; set; }
        public virtual UnitOfMeasure Uom { get; set; }
    }
}
