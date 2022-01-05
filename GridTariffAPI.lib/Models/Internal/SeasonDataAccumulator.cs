using GridTariffApi.Lib.Models.Digin;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Models.Internal
{
    class SeasonDataAccumulator
    {
        public SeasonDataAccumulator()
        {
            PowerPricesDaysInMonthProcessed = new bool[31 + 1];
            TariffPrice = new TariffPrice
            {
                PriceInfo = new PriceInfo()
            };
            TariffPrice.PriceInfo.FixedPrices = new List<Models.Digin.FixedPrices>();
            TariffPrice.PriceInfo.PowerPrices = new List<Models.Digin.PowerPrices>();
            TariffPrice.PriceInfo.EnergyPrices = new List<Models.Digin.EnergyPrices>();
            TariffPrice.Hours = new List<Hours>();
            Taxes = new PriceStructure.Taxes();
        }
        public bool[] PowerPricesDaysInMonthProcessed { get; set; }

        public TariffPrice TariffPrice { get; set; }

        public Models.PriceStructure.Taxes Taxes { get; set; }
    }
}
