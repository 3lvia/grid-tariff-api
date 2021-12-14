using GridTariffApi.Lib.Controllers.v1;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Models;
using GridTariffApi.Lib.Services.TariffType;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace GridTariffApi.Controllers.Tests
{
    public class TariffTypeControllerTests
    {
        private PilotTariffTypeController _tariffTypeController;
        private TariffTypeService _tariffTypeService;
        private TariffContext _tariffContext;

        private void Setup()
        {

            var services = new ServiceCollection();
            var db = Guid.NewGuid().ToString();
            services.AddDbContext<TariffContext>(u => u.UseInMemoryDatabase(databaseName: db));

            var provider = services.BuildServiceProvider();
            _tariffContext = provider.GetRequiredService<TariffContext>();
            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffTypeController = new PilotTariffTypeController(_tariffTypeService);
            TestHelper testHelper = new TestHelper();
            _tariffContext.Company.Add(testHelper.GetCompanyElvia());
            _tariffContext.Company.Add(testHelper.GetCompanyFoobar());
            _tariffContext.TariffType.Add(testHelper.GetTariffRush());
            GridTariffApi.Lib.EntityFramework.TariffType dayNight = testHelper.GetTariffDayNight();
            dayNight.CompanyId = 2;
            _tariffContext.TariffType.Add(dayNight);
            _tariffContext.SaveChanges();
        }


        [Fact()]
        public void NullPointerTest()
        {
            Setup();
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            Assert.NotNull(tariffTypeContainer);
            Assert.NotNull(tariffTypeContainer.TariffTypes);
            foreach (var tariffTypeResult in tariffTypeContainer.TariffTypes)
            {
                Assert.NotNull(tariffTypeResult);
            }
        }

        [Fact()]
        public void ObjectTest()
        {
            Setup();
            TestHelper testHelper = new TestHelper();
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            Assert.Equal(2, tariffTypeContainer.TariffTypes.Count);

            GridTariffApi.Lib.EntityFramework.TariffType tariffTypeRush = _tariffContext.TariffType.Where(t => t.TariffKey.Equals("private_tou_rush")).Include(t => t.Company).FirstOrDefault();
            Assert.True(testHelper.Contains(tariffTypeContainer.TariffTypes, tariffTypeRush));

            GridTariffApi.Lib.EntityFramework.TariffType tariffTypeDayNight = _tariffContext.TariffType.Where(t => t.TariffKey.Equals("private_tou_daynight")).Include(t => t.Company).FirstOrDefault();
            Assert.True(testHelper.Contains(tariffTypeContainer.TariffTypes, tariffTypeDayNight));
        }
    }
}

