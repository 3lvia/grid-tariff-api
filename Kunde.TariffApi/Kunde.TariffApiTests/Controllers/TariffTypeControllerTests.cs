using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kunde.TariffApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Elvia.Telemetry;
using Xunit;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kunde.TariffApi.Models;
using Kunde.TariffApiTests;
using System.Linq;

namespace Kunde.TariffApi.Controllers.Tests
{
    [TestClass()]
    public class TariffTypeControllerTests
    {
        private Mock<ITelemetryInsightsLogger> _mockLogger;
        private TariffTypeController _tariffTypeController;
        private TariffTypeService _tariffTypeService;
        private TariffContext _tariffContext;

        private void Setup()
        {
            _mockLogger = new Mock<ITelemetryInsightsLogger>();

            var services = new ServiceCollection();
            var db = Guid.NewGuid().ToString();
            services.AddDbContext<TariffContext>(u => u.UseInMemoryDatabase(databaseName: db));

            var provider = services.BuildServiceProvider();
            _tariffContext = provider.GetRequiredService<TariffContext>();

            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffTypeController = new TariffTypeController(_tariffTypeService, _mockLogger.Object);

            TestHelper testHelper = new TestHelper();

            _tariffContext.Company.Add(testHelper.GetCompanyElvia());
            _tariffContext.Company.Add(testHelper.GetCompanyFoobar());

            _tariffContext.Tarifftype.Add(testHelper.GetTariffRush());
            Tarifftype dayNight = testHelper.GetTariffDayNight();
            dayNight.Companyid = 2;
            _tariffContext.Tarifftype.Add(dayNight);

            _tariffContext.SaveChanges();
        }


        [TestMethod()]
        public void NullPointerTest()
        {
            Setup();
            TestHelper testHelper = new TestHelper();
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            Assert.IsNotNull(tariffTypeContainer);
            Assert.IsNotNull(tariffTypeContainer.TariffTypes);
            foreach (var tariffTypeResult in tariffTypeContainer.TariffTypes)
            {
                Assert.IsNotNull(tariffTypeResult);
            }

        }

        [TestMethod()]
        public void ObjectTest()
        {
            Setup();
            TestHelper testHelper = new TestHelper();
            TariffTypeContainer tariffTypeContainer = _tariffTypeService.GetTariffTypes();
            Assert.AreEqual(2, tariffTypeContainer.TariffTypes.Count);

            Tarifftype tariffTypeRush = _tariffContext.Tarifftype.Where(t => t.Tariffkey.Equals("private_tou_rush")).Include(t => t.Company).FirstOrDefault();
            Assert.IsTrue(testHelper.Contains(tariffTypeContainer.TariffTypes, tariffTypeRush));

            Tarifftype tariffTypeDayNight = _tariffContext.Tarifftype.Where(t => t.Tariffkey.Equals("private_tou_daynight")).Include(t => t.Company).FirstOrDefault(); ;
            Assert.IsTrue(testHelper.Contains(tariffTypeContainer.TariffTypes, tariffTypeDayNight));
        }
    }
}
   

namespace Kunde.TariffApiTests.Controllers
{

    class TariffTypeControllerTests
    {
    }
}
