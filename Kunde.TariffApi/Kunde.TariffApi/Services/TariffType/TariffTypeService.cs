using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kunde.TariffApi.Services.TariffType
{
    public class TariffTypeService : ITariffTypeService
    {
        private TariffContext _tariffContext;
        public TariffTypeService(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public TariffTypeContainer GetTariffTypes()
        {
            TariffTypeContainer tariffTypeContainer = new TariffTypeContainer();
            tariffTypeContainer.TariffTypes = new List<Models.TariffType>();

            foreach (var tariffType in _tariffContext.Tarifftype.Include(t => t.Company))
            {
                tariffTypeContainer.TariffTypes.Add(new Models.TariffType()
                {
                    TariffKey = tariffType.Tariffkey,
                    Company = tariffType.Company.CompanyName,
                    CustomerType = tariffType.Customertype,
                    Title = tariffType.Title,
                    Resolution = tariffType.Resolution,
                    Description = tariffType.Description
                });
            }
            return tariffTypeContainer;
        }
    }
}
