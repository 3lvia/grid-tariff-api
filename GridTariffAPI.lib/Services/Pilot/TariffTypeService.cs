using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Models.Pilot.TariffType;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GridTariffApi.Lib.Services.Pilot
{
    public class TariffTypeService : ITariffTypeService
    {
        private readonly TariffContext _tariffContext;
        public TariffTypeService(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public TariffTypeContainer GetTariffTypes()
        {
            TariffTypeContainer tariffTypeContainer = new TariffTypeContainer();
            tariffTypeContainer.TariffTypes = _tariffContext.TariffType.Include(t => t.Company).Select(tariffType => new Models.Pilot.TariffType.TariffType
            {
                TariffKey = tariffType.TariffKey,
                Company = tariffType.Company.CompanyName,
                CustomerType = tariffType.CustomerType,
                Title = tariffType.Title,
                Resolution = tariffType.Resolution,
                Description = tariffType.Description
            }).ToList();
            return tariffTypeContainer;
        }
    }
}
