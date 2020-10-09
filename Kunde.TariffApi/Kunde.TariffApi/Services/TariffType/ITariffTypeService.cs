using Kunde.TariffApi.Models;
using System.Collections.Generic;

namespace Kunde.TariffApi.Services.TariffType
{
    public interface ITariffTypeService
    {
        TariffTypeContainer GetTariffTypes();
    }
}