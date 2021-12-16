using GridTariffApi.Lib.Models.V2.Digin;

namespace GridTariffApi.Lib.Models.Internal
{
    public class HourSeasonIndex
    {
        public PriceElement FixedPriceValue { get; set; }
        public PriceElement PowerPriceValue{ get; set; }

        public EnergyInformation EnergyInformation { get; set; }
        public EnergyInformation EnergyInformationHoliday { get; set; }
        public EnergyInformation EnergyInformationWeekend { get; set; }
    }

    public class PriceElement
    {
        public string Id { get; set; }
        public string IdDaysInMonth { get; set; }
    }

    public class EnergyInformation
    {
        public EnergyPrices[] HourArray { get; set; }
    }
}
