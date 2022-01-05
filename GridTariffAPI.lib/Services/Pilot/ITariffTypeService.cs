
using GridTariffApi.Lib.Models.Pilot.TariffType;

namespace GridTariffApi.Lib.Services.Pilot
{
    public interface ITariffTypeService
    {
        TariffTypeContainer GetTariffTypes();
    }
}