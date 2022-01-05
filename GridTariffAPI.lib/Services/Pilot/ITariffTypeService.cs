
using GridTariffApi.Lib.Models;

namespace GridTariffApi.Lib.Services.Pilot
{
    public interface ITariffTypeService
    {
        TariffTypeContainer GetTariffTypes();
    }
}