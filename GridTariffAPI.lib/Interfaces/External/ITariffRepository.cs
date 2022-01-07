using GridTariffApi.Lib.Models.PriceStructure;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface ITariffRepository
    {
        public TariffPriceStructureRoot GetTariffPriceStructure();
    }
}
