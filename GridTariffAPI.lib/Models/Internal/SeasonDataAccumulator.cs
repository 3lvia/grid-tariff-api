using GridTariffApi.Lib.Models.V2.Digin;
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
            TariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
            TariffPrice.PriceInfo.PowerPrices = new List<Models.V2.Digin.PowerPrices>();
            TariffPrice.PriceInfo.EnergyPrices = new List<Models.V2.Digin.EnergyPrices>();
            TariffPrice.Hours = new List<Hours>();
            Taxes = new V2.PriceStructure.Taxes();
        }
        public bool[] PowerPricesDaysInMonthProcessed { get; set; }

        public TariffPrice TariffPrice { get; set; }

        public Models.V2.PriceStructure.Taxes Taxes { get; set; }
    }
}
