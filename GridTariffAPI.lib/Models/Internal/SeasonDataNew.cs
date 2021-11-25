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
            EnergyPricesDaysInMonthProcessed = new bool[31 + 1]; //todo constant
            TariffPrice = new TariffPrice();
            TariffPrice.PriceInfo = new PriceInfo();
            TariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
            TariffPrice.PriceInfo.PowerPrices = new List<Models.V2.Digin.PowerPrices>();
            TariffPrice.PriceInfo.EnergyPrices = new List<Models.V2.Digin.EnergyPrices>();
            TariffPrice.Hours = new List<Hours>();
            Taxes = new V2.PriceStructure.Taxes();
        }
        public bool[] FixedPricesDaysInMonthProcessed { get; set; }
        public bool[] PowerPricesDaysInMonthProcessed { get; set; }
        public bool[] EnergyPricesDaysInMonthProcessed { get; set; }

        public TariffPrice TariffPrice { get; set; }

        public Models.V2.PriceStructure.Taxes Taxes { get; set; }
        //        public List<Hours> Hours { get; set; }
    }
}
