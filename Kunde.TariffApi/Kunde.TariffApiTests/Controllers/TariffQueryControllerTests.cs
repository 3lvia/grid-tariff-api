using Kunde.TariffApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Elvia.Telemetry;
using Moq;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Kunde.TariffApiTests;
using Microsoft.EntityFrameworkCore;
using Kunde.TariffApi.Services.TariffQuery;
using Microsoft.AspNetCore.Mvc;
using k8s.Models;
using Kunde.TariffApi.Models.TariffQuery;
using System.Linq;
using Xunit;

namespace Kunde.TariffApi.Controllers.Tests
{
    public class TariffQueryControllerTests
    {
        private Mock<ITelemetryInsightsLogger> _mockLogger;
        private TariffQueryController _tariffQueryController;
        private TariffQueryService _TariffQueryService;

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

            _TariffQueryService = new TariffQueryService(_tariffContext);
            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffQueryController = new TariffQueryController(_mockLogger.Object, _tariffTypeService, _TariffQueryService);

            TestHelper testHelper = new TestHelper();

            _tariffContext.Add(testHelper.GetCompanyElvia());
            _tariffContext.Add(testHelper.GetCompanyFoobar());

            _tariffContext.Add(testHelper.GetTariffRush());
            Tarifftype dayNight = testHelper.GetTariffDayNight();
            dayNight.Companyid = 2;
            _tariffContext.Add(dayNight);

            _tariffContext.AddRange(testHelper.GetUoms());
            _tariffContext.AddRange(testHelper.GetSeasons());
            _tariffContext.AddRange(testHelper.GetPublicHolidays());
            _tariffContext.AddRange(testHelper.GetPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPriceConfigs());
            _tariffContext.AddRange(testHelper.GetVariablePriceConfigs());
            _tariffContext.SaveChanges();
        }

        [Fact()]
        public void GETEmptyCommandTest()
        {
            Setup();
            var  actionResult = _tariffQueryController.Get(null);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush" });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETRangeAndStartDateTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.Now });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETRangeAndEndDateTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush", EndTime = DateTime.Now });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNonExistingTariffKeyTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "NotExisting"});
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }



        [Fact()]
        public void GETBothDatesMissingTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush"});
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }


        [Fact()]
        public void GETStartDateMissingTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush", EndTime = DateTime.MaxValue });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETEndDateMissingTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.MaxValue });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void StartDateGreaterTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(new Models.TariffQuery.TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.MaxValue, EndTime = DateTime.MinValue });
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }
    }
}