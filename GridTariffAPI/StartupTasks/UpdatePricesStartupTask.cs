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
        private static readonly string _tariffPriceFileName = Path.Join("Artifacts", "GridTariffPriceConfiguration.v1_0_gridtariffprices.json");

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

            elviaPrices.Company = elviaCompany;
            elviaPrices.JsonPayload = await GetPricesPayload();
            elviaPrices.JsonVersion = "1.0";
            elviaPrices.LastUpdatedUtc = DateTimeOffset.UtcNow;

            await elviaDbContext.SaveChangesAsync();
        }

        public virtual async Task<string> GetPricesPayload()
        {
            return await File.ReadAllTextAsync(_tariffPriceFileName);
        }

        public async Task<PriceStructure> GetElviaPrices(ElviaDbContext elviaDbContext, Company elviaCompany)
        {
            var elviaPriceStructure = elviaDbContext.PriceStructure.FirstOrDefault(x => x.Company.OrgNumber == elviaCompany.OrgNumber);
            if (elviaPriceStructure == null)
            {
                elviaPriceStructure = new PriceStructure() { Company = elviaCompany };
                await elviaDbContext.PriceStructure.AddAsync(elviaPriceStructure);
                await elviaDbContext.SaveChangesAsync();
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
