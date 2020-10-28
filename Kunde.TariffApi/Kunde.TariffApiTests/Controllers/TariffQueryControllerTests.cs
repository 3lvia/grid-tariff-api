using Kunde.TariffApi.Controllers.v1;
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
using Kunde.TariffApi.Config;
using System.ComponentModel.DataAnnotations;
using System.Collections;

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

            TariffQueryValidationSettings tariffQueryValidationSettings = new TariffQueryValidationSettings() { MinStartDateAllowed = new DateTime(2020, 11, 01)};
            _TariffQueryService = new TariffQueryService(_tariffContext);
            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffQueryController = new TariffQueryController(_mockLogger.Object, _tariffTypeService, _TariffQueryService, tariffQueryValidationSettings);

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
        public void GETStartTestBeforeMinDateTest()
        {
            Setup();
            TariffQueryRequest tariffQuery = new TariffQueryRequest() { TariffKey = "private_tou_rush", Range = "today", StartTime = new DateTime(2020,01,01), EndTime = DateTime.MaxValue};
            var actionResult = _tariffQueryController.Get(null);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() {  TariffKey = "private_tou_rush" } ;
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count());
        }

        [Fact()]
        public void GETRangeAndStartDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() {  TariffKey = "private_tou_rush", Range = "today", StartTime = DateTime.Now };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETRangeAndEndDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", Range = "today", EndTime = DateTime.Now };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETNonExistingTariffKeyTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "NotExisting" };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count());
        }

        [Fact()]
        public void GETBothDatesMissingTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush"};
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3,validationResults.Count());
        }


        [Fact()]
        public void GETStartDateMissingTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", EndTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETEndDateMissingTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void StartDateGreaterTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.MaxValue, EndTime = DateTime.MinValue };
            List<ValidationResult>  validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }
    }
}