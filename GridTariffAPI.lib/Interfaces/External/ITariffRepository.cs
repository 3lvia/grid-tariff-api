using System.Threading.Tasks;
using GridTariffApi.Lib.Models.PriceStructure;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface ITariffRepository
    {
        public Task<TariffPriceStructureRoot> GetTariffPriceStructureAsync();
    }
}
