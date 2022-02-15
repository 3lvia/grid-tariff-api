using GridTariffApi.Database;
using GridTariffApi.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.StartupTasks
{
    public class UpdatePricesStartupTask : IStartupTask
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly string TariffPriceFileName = Path.Join("Artifacts", "GridTariffPriceConfiguration.v1_0_gridtariffprices.json");

        private readonly string _elviaCompanyName = "Elvia AS";
        private readonly string _elviaCompanyOrgNumber = "980489698";

        public UpdatePricesStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute()
        {
            using var scope = _serviceProvider.CreateScope();
            var elviaDbContext = scope.ServiceProvider.GetRequiredService<ElviaDbContext>();
            var elviaCompany = await GetElviaCompany(elviaDbContext);
            var elviaPrices = await GetElviaPrices(elviaDbContext,elviaCompany);

            elviaPrices.JsonPayload = await File.ReadAllTextAsync(TariffPriceFileName);
            elviaPrices.JsonVersion = "1.0";
            elviaPrices.LastUpdatedUtc = DateTimeOffset.UtcNow;

            await elviaDbContext.SaveChangesAsync();
        }

        public async Task<PriceStructure> GetElviaPrices(ElviaDbContext elviaDbContext, Company elviaCompany)
        {
            var elviaPriceStructure = elviaDbContext.PriceStructure.FirstOrDefault(x => x.Company.OrgNumber == elviaCompany.OrgNumber);
            if (elviaPriceStructure == null)
            {
                elviaPriceStructure = new PriceStructure() { Company = elviaCompany };
                await elviaDbContext.AddAsync(elviaPriceStructure);
            }
            return elviaPriceStructure;
        }


        public async Task<Company> GetElviaCompany(ElviaDbContext elviaDbContext)
        {
            var elviaCompany = elviaDbContext.Company.FirstOrDefault(x => x.OrgNumber == _elviaCompanyOrgNumber);
            if (elviaCompany == null)
            {
                elviaCompany = new Company()
                {
                    OrgNumber = _elviaCompanyOrgNumber,
                    Name = _elviaCompanyName
                };
                elviaDbContext.Company.Add(elviaCompany);
                await elviaDbContext.SaveChangesAsync();
            }
            return elviaCompany;
        }

    }
}
