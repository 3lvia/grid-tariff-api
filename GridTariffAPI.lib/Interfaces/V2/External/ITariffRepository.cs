using GridTariffApi.Lib.Models.V2.PriceStructure;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface ITariffRepository
    {
        public TariffPriceStructureRoot GetTariffPriceStructure();
    }
}
