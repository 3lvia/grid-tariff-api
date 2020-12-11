using Kunde.TariffApi.Config;

namespace Kunde.TariffApi.Services.Config
{
    public interface IConfigHandler
    {
        GridTariffApiConfig GetConfig(GridTariffApiConfig gridTariffAPIConfig);
    }
}
