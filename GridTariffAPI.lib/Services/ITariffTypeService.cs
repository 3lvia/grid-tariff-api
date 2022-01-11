using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffTypeService
    {
        Task<Models.Digin.TariffTypeContainer> GetTariffTypes();
    }
}
