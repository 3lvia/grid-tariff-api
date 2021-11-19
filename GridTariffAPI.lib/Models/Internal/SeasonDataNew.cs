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
            fixedPricesDaysInMonthProcessed = new bool[31+1]; //todo constant
            TariffPrice = new TariffPrice();
            TariffPrice.PriceInfo = new PriceInfo();
            TariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
        }
        public bool[] fixedPricesDaysInMonthProcessed { get; set; }
        public TariffPrice TariffPrice { get; set; }
//        public List<Hours> Hours { get; set; }
    }
}
