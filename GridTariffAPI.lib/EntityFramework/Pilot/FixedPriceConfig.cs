using System;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class FixedPriceConfig
    {
        public int Id { get; set; }
        public int TariffTypeId { get; set; }
        public int SeasonId { get; set; }
        public int MonthNo { get; set; }
        public int PriceLevelId { get; set; }
        public decimal Total { get; set; }
        public decimal Fixed { get; set; }
        public decimal Taxes { get; set; }
        public int UomId { get; set; }
        public DateTime PriceFromDate { get; set; }
        public DateTime PriceToDate { get; set; }

        public virtual FixedPriceLevel PriceLevel { get; set; }
        public virtual Season Season { get; set; }
        public virtual TariffType TariffType { get; set; }
        public virtual UnitOfMeasure Uom { get; set; }
    }
}
