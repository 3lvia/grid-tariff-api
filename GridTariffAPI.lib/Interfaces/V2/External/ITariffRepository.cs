using GridTariffApi.Lib.Models.PriceStructure;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface ITariffRepository
    {
        public TariffPriceStructureRoot GetTariffPriceStructure();
    }
}
