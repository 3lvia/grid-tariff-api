using GridTariffApi.Lib.Models.V2.Digin;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Models.Internal
{
    class SeasonDataNew
    {
        public SeasonDataNew()
        {
            FixedPricesDaysInMonthProcessed = new bool[31 + 1]; //todo constant
            PowerPricesDaysInMonthProcessed = new bool[31 + 1]; //todo constant
            TariffPrice = new TariffPrice();
            TariffPrice.PriceInfo = new PriceInfo();
            TariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
            TariffPrice.PriceInfo.PowerPrices = new List<Models.V2.Digin.PowerPrices>();
        }
        public bool[] FixedPricesDaysInMonthProcessed { get; set; }
        public bool[] PowerPricesDaysInMonthProcessed { get; set; }
        public TariffPrice TariffPrice { get; set; }
//        public List<Hours> Hours { get; set; }
    }
}
