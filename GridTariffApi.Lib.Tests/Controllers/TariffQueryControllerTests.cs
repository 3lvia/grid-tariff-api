using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Controllers.v1;
using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Services.TariffType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace GridTariffApi.Controllers.Tests
{
    public class TariffQueryControllerTests
    {
        private TariffQueryController _tariffQueryController;
        private TariffQueryService _TariffQueryService;

        private TariffTypeService _tariffTypeService;
        private TariffContext _tariffContext;
        private IServiceHelper _serviceHelper;

        private void Setup()
        {

            var services = new ServiceCollection();
            var db = Guid.NewGuid().ToString();
            services.AddDbContext<TariffContext>(u => u.UseInMemoryDatabase(databaseName: db));

            var provider = services.BuildServiceProvider();
            _tariffContext = provider.GetRequiredService<TariffContext>();

            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig() { MinStartDateAllowedQuery = new DateTime(2020, 11, 01) };
            gridTariffApiConfig.TimeZoneForQueries = NorwegianTimeZoneInfo();

            _serviceHelper = new ServiceHelper(gridTariffApiConfig);
            _TariffQueryService = new TariffQueryService(_tariffContext);
            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffQueryController = new TariffQueryController(_tariffTypeService, _TariffQueryService, gridTariffApiConfig, _serviceHelper);

            TestHelper testHelper = new TestHelper();

            _tariffContext.Add(testHelper.GetCompanyElvia());
            _tariffContext.Add(testHelper.GetCompanyFoobar());

            _tariffContext.Add(testHelper.GetTariffRush());
            GridTariffApi.Lib.EntityFramework.TariffType dayNight = testHelper.GetTariffDayNight();
            dayNight.CompanyId = 2;
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


        private static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }

        [Fact()]
        public void GETEmptyCommandTest()
        {
            Setup();
            var actionResult = _tariffQueryController.Get(null);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETStartTestBeforeMinDateTest()
        {
            Setup();
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", StartTime = DateTime.UtcNow.AddYears(-10), EndTime = DateTime.UtcNow };
            var actionResult = _tariffQueryController.Get(tariffQueryRequest);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush" };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count);
        }

        [Fact()]
        public void GETRangeAndStartDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", Range = "today", StartTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETRangeAndEndDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "private_tou_rush", Range = "today", EndTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETNonExistingTariffKeyTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest() { TariffKey = "NotExisting" };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count);
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
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETStartDateBeforeMinDateMeteringPointTest()
        {
            Setup();
            var request = new TariffQueryRequestMeteringPoints() { StartTime = DateTime.UtcNow.AddYears(-10), EndTime = DateTime.UtcNow };
            var actionResult = _tariffQueryController.GridTariffsByMeteringPoints(request);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints();
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count);
        }

        [Fact()]
        public void GETRangeAndStartDateMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints() { Range = "today", StartTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETRangeAndEndDateMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints() { Range = "today", EndTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }


        [Fact()]
        public void GETStartDateMissingMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints() {  EndTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETEndDateMissingMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints() { StartTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void StartDateGreaterMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints() { StartTime = DateTime.MaxValue, EndTime = DateTime.MinValue };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }
    }
}