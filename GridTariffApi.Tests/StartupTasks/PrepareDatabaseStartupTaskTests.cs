using GridTariffApi.Database;
using GridTariffApi.StartupTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Tests.StartupTasks
{
    public class PrepareDatabaseStartupTaskTests
    {
        private IServiceProvider? _serviceProvider;
        private PrepareDatabaseStartupTask? _prepareDatabaseStartupTask;

        private void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            _serviceProvider = services.BuildServiceProvider();
            _prepareDatabaseStartupTask = new PrepareDatabaseStartupTask(_serviceProvider);
        }

        [Fact]
        public async Task ExecuteTest()
        {
            const string jsonPayload = "abc123";
            const string version = "1.0";

            var services = new ServiceCollection();
            services.AddDbContext<ElviaDbContext>(u => u.UseInMemoryDatabase(databaseName: "ExecuteTest"));
            var serviceProvider = services.BuildServiceProvider();

            var mockPrepareDatabaseStartupTask = new Mock<PrepareDatabaseStartupTask>(serviceProvider);
            mockPrepareDatabaseStartupTask.Setup(x => x.GetPricesPayload()).Returns(Task.FromResult(jsonPayload));
            mockPrepareDatabaseStartupTask.CallBase = true;

            await mockPrepareDatabaseStartupTask.Object.Execute();
            var elviaDbContext = serviceProvider!.GetRequiredService<ElviaDbContext>();

            var elviaPrices = await elviaDbContext.PriceStructure.Include(x => x.Company).FirstOrDefaultAsync();
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
            Assert.NotNull(elviaPrices);
            Assert.Equal(jsonPayload, elviaPrices.JsonPayload);
            Assert.Equal(version, elviaPrices.JsonVersion);
            Assert.Equal(DateTimeOffset.UtcNow.Date, elviaPrices.LastUpdatedUtc.Date);
            Assert.NotNull(elviaPrices.Company);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());

            await mockPrepareDatabaseStartupTask.Object.Execute();
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

            var elviaCompany = await _prepareDatabaseStartupTask!.GetElviaCompany(elviaDbContext);
            var priceStructure = await _prepareDatabaseStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
            Assert.Equal(elviaCompany.OrgNumber, priceStructure.Company.OrgNumber);
            Assert.Equal(1, await elviaDbContext.PriceStructure.CountAsync());
            await _prepareDatabaseStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
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

            var elviaCompany = await _prepareDatabaseStartupTask!.GetElviaCompany(elviaDbContext);
            var priceStructure = await _prepareDatabaseStartupTask.GetElviaPrices(elviaDbContext, elviaCompany);
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

            var elviaCompany = await _prepareDatabaseStartupTask!.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany);
            Assert.Equal(elviaCompanyName, elviaCompany.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());

            var elviaCompany2 = await _prepareDatabaseStartupTask.GetElviaCompany(elviaDbContext);
            Assert.NotNull(elviaCompany2);
            Assert.Equal(elviaCompanyName, elviaCompany2.Name);
            Assert.Equal(_elviaCompanyOrgNumber, elviaCompany2.OrgNumber);
            Assert.Equal(1, await elviaDbContext.Company.CountAsync());
        }

    }
}
