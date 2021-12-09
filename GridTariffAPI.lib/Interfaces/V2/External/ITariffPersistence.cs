using GridTariffApi.Lib.Models.V2.PriceStructure;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface ITariffPersistence
    {
        public TariffPriceStructureRoot GetTariffPriceStructure();
    }
}
