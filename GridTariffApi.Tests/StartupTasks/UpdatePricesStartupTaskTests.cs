using GridTariffApi.Database;
using GridTariffApi.StartupTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Tests.StartupTasks
{
    public class UpdatePricesStartupTaskTests
    {
        private IServiceProvider? _serviceProvider;
        private UpdatePricesStartupTask? _updatePricesStartupTask;

        private void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            _serviceProvider = services.BuildServiceProvider();
            _updatePricesStartupTask = new UpdatePricesStartupTask(_serviceProvider);
        }

        [Fact]
        public async Task ExecuteTest()
        {
            const string jsonPayload = "abc123";
            const string version = "1.0";

            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: "ExecuteTest"));
            var serviceProvider = services.BuildServiceProvider();

            var mockUpdatePricesStartupTask = new Mock<UpdatePricesStartupTask>(serviceProvider);
            mockUpdatePricesStartupTask.Setup(x => x.GetPricesPayload()).Returns(Task.FromResult(jsonPayload));
            mockUpdatePricesStartupTask.CallBase = true;

            await mockUpdatePricesStartupTask.Object.Execute();
            var elviaDbContext = serviceProvider!.GetRequiredService<ElviaDbContext>();

            var elviaPrices = await elviaDbContext.PriceStructure.Include(x => x.Company).FirstOrDefaultAsync();
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
            Assert.NotNull(elviaPrices);
            Assert.Equal(jsonPayload, elviaPrices.JsonPayload);
            Assert.Equal(version, elviaPrices.JsonVersion);
            Assert.Equal(DateTimeOffset.UtcNow.Date, elviaPrices.LastUpdatedUtc.Date);
            Assert.NotNull(elviaPrices.Company);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());

            await mockUpdatePricesStartupTask.Object.Execute();
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());
        }


        [Fact]
        public async Task GetElviaPricesHitTest()
        {
            Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.Company.FirstOrDefaultAsync());
            Assert.Null(await elviaDbContext.PriceStructure.FirstOrDefaultAsync());

            var elviaCompany = await _updatePricesStartupTask!.GetElviaCompany(elviaDbContext);
            var priceStructure = await _updatePricesStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
            Assert.Equal(elviaCompany.OrgNumber, priceStructure.Company.OrgNumber);
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
            await _updatePricesStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
            Assert.Equal(elviaCompany.OrgNumber, priceStructure.Company.OrgNumber);
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
        }


        [Fact]
        public async Task GetElviaPricesMissTest()
        {
            Setup();

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.Company.FirstOrDefaultAsync());
            Assert.Null(await elviaDbContext.PriceStructure.FirstOrDefaultAsync());

            var elviaCompany = await _updatePricesStartupTask!.GetElviaCompany(elviaDbContext);
            var priceStructure = await _updatePricesStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
            Assert.Equal(elviaCompany.OrgNumber, priceStructure.Company.OrgNumber);
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
        }

        [Fact]
        public async Task GetElviaCompanyTest()
        {
            Setup();
            string elviaCompanyName = "Elvia AS";
            string _elviaCompanyOrgNumber = "980489698";

            var elviaDbContext = _serviceProvider!.GetRequiredService<ElviaDbContext>();
            Assert.Null(await elviaDbContext.Company.FirstOrDefaultAsync());

            var elviaCompany = await _updatePricesStartupTask!.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany);
            Assert.Equal(elviaCompanyName, elviaCompany.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());

            var elviaCompany2 = await _updatePricesStartupTask.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany2);
            Assert.Equal(elviaCompanyName, elviaCompany2.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany2.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());
        }

    }
}
