using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Kunde.TariffApi.Services.TariffType
{
    public class TariffTypeService : ITariffTypeService
    {
        private IServiceScopeFactory _scopeFactory;
        private TariffContext _tariffContext;
        private static string _tableCompany = "Company";
        public TariffTypeService(IServiceScopeFactory scopeFactory, TariffContext tariffContext)
        {
            _scopeFactory = scopeFactory;
            _tariffContext = tariffContext;
        }

        public TariffTypeContainer GetTariffTypes()
        {
            TariffTypeContainer tariffTypeContainer = new TariffTypeContainer();
            tariffTypeContainer.TariffTypes = new List<Models.TariffType>();
            List<Models.TariffType> retVal = new List<Models.TariffType>();
            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                using (TariffContext dbContext = scope.ServiceProvider.GetRequiredService<TariffContext>())
                {
                    foreach (var tariffType in dbContext.Tarifftype.Include(_tableCompany))
                    {
                        tariffTypeContainer.TariffTypes.Add(new Models.TariffType()
                        {
                            TariffKey = tariffType.Tariffkey,
                            Company = tariffType.Company.Company1,
                            CustomerType = tariffType.Customertype,
                            Title = tariffType.Title,
                            Resolution = tariffType.Resolution,
                            Description = tariffType.Description
                        });
                    }
                };
            };
            return tariffTypeContainer;
        }
    }
}
