using System;

namespace GridTariffApi.Lib.Models.TariffQuery
{
    public class VariablePrice
    {
        public Decimal Total { get; set; }
        public Decimal Energy { get; set; }
        public Decimal Power { get; set; }
        public Decimal Taxes { get; set; }
        public String Level { get; set; }
        public String Currency { get; set; }
        public String Uom { get; set; }
    }
}
