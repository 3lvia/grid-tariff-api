using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kunde.TariffApi.Services.TariffType
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
            tariffTypeContainer.TariffTypes = _tariffContext.Tarifftype.Include(t => t.Company).Select(tariffType => new Models.TariffType
            {
                TariffKey = tariffType.Tariffkey,
                Company = tariffType.Company.CompanyName,
                CustomerType = tariffType.Customertype,
                Title = tariffType.Title,
                Resolution = tariffType.Resolution,
                Description = tariffType.Description
            }).ToList();
            return tariffTypeContainer;
        }
    }
}
