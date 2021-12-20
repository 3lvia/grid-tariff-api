using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
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
using Xunit;

namespace GridTariffApi.Lib.Tests.Controllers
{
    public class TariffQueryControllerTests
    {
        private PilotTariffQueryController _tariffQueryController;
        private TariffQueryService _tariffQueryService;

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

            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig { MinStartDateAllowedQuery = new DateTime(2020, 11, 01) };
            gridTariffApiConfig.TimeZoneForQueries = NorwegianTimeZoneInfo();

            _serviceHelper = new ServiceHelper(gridTariffApiConfig);
            _tariffQueryService = new TariffQueryService(_tariffContext, _serviceHelper);
            _tariffTypeService = new TariffTypeService(_tariffContext);
            _tariffQueryController = new PilotTariffQueryController(_tariffTypeService, _tariffQueryService, gridTariffApiConfig, _serviceHelper);

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
            _tariffContext.AddRange(testHelper.GetMeteringPointProducts());
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
            BadRequestObjectResult result = actionResult.Result as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETStartTestBeforeMinDateTest()
        {
            Setup();
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", StartTime = DateTime.UtcNow.AddYears(-10), EndTime = DateTime.UtcNow };
            var actionResult = _tariffQueryController.Get(tariffQueryRequest);
            BadRequestObjectResult result = actionResult.Result as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush" };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count);
        }

        [Fact()]
        public void GETRangeAndStartDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", Range = "today", StartTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETRangeAndEndDateTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", Range = "today", EndTime = DateTime.UtcNow };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETNonExistingTariffKeyTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "NotExisting" };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Equal(3, validationResults.Count);
        }

        [Fact()]
        public void GETStartDateMissingTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", EndTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETEndDateMissingTest()
        {
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", StartTime = DateTime.MaxValue };
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void StartDateGreaterTest()
        {
            DateTime startDate = new DateTime(2021, 05, 25);
            TariffQueryRequest tariffQueryRequest = new TariffQueryRequest { TariffKey = "private_tou_rush", StartTime = startDate, EndTime = startDate.AddDays(-1)} ;
            List<ValidationResult> validationResults = tariffQueryRequest.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETStartDateBeforeMinDateMeteringPointTest()
        {
            Setup();
            var request = new TariffQueryRequestMeteringPoints { StartTime = DateTime.UtcNow.AddYears(-10), EndTime = DateTime.UtcNow };
            var actionResult = _tariffQueryController.GridTariffsByMeteringPoints(request);
            BadRequestObjectResult result = actionResult.Result as BadRequestObjectResult;
            Assert.Equal(400, result.StatusCode);
        }

        [Fact()]
        public void GETNoRangeOrPeriodMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints();
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Equal(4, validationResults.Count);
        }

        [Fact()]
        public void GETRangeAndStartDateMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints { Range = "today", StartTime = DateTime.UtcNow, MeteringPointIds = new List<string>() };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETRangeAndEndDateMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints { Range = "today", EndTime = DateTime.UtcNow, MeteringPointIds = new List<string>()};
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }


        [Fact()]
        public void GETStartDateMissingMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints {  EndTime = DateTime.MaxValue, MeteringPointIds = new List<string>() };
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void GETEndDateMissingMeteringPointTest()
        {
            var request = new TariffQueryRequestMeteringPoints { StartTime = DateTime.MaxValue, MeteringPointIds = new List<string>()};
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void StartDateGreaterMeteringPointTest()
        {
            DateTime startDate = new DateTime(2021, 05, 25);
            var request = new TariffQueryRequestMeteringPoints { StartTime = startDate, EndTime = startDate.AddDays(-1) , MeteringPointIds = new List<string>()};
            List<ValidationResult> validationResults = request.Validate(null).ToList();
            Assert.Single(validationResults);
        }

        [Fact()]
        public void NorwegianWinterTimeTest()
        {
            Setup();
            var startDateTime = new DateTimeOffset(new DateTime(2021, 01, 04, 0, 0, 0), new TimeSpan(1, 0, 0));
            var endDateTime = new DateTimeOffset(new DateTime(2021, 01, 05, 0, 0, 0), new TimeSpan(1, 0, 0));
            var request = new TariffQueryRequestMeteringPoints { MeteringPointIds = new List<string> { "abc1" }, StartTime = startDateTime, EndTime = endDateTime };
            List<PriceInfo> priceInfos = ExecuteRequestAndInitialVerify(request);
            Assert.Equal(24, priceInfos.Count);
            AssertCorrectHours(startDateTime, priceInfos);
            VerifyPriceInfo(startDateTime, priceInfos, "00-01", 0.2890);
            VerifyPriceInfo(startDateTime.AddHours(23), priceInfos, "23-24", 0.2890);
            VerifyPriceInfo(startDateTime.AddHours(5), priceInfos, "05-06", 0.2890);
            VerifyPriceInfo(startDateTime.AddHours(6), priceInfos, "06-07", 0.5805);
            VerifyPriceInfo(startDateTime.AddHours(15), priceInfos, "15-16", 0.5805);
            VerifyPriceInfo(startDateTime.AddHours(16), priceInfos, "16-17", 0.8470);
            VerifyPriceInfo(startDateTime.AddHours(19), priceInfos, "19-20", 0.8470);
            VerifyPriceInfo(startDateTime.AddHours(20), priceInfos, "20-21", 0.5805);
        }

        private List<PriceInfo> ExecuteRequestAndInitialVerify(TariffQueryRequestMeteringPoints request)
        {
            var okObjectResult = _tariffQueryController.GridTariffsByMeteringPoints(request).Result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            TariffQueryRequestMeteringPointsResult result = okObjectResult.Value as TariffQueryRequestMeteringPointsResult;
            Assert.NotNull(result);
            Assert.Single(result.GridTariffCollections);
            var gridTariffCollection = result.GridTariffCollections.First();
            var priceInfos = gridTariffCollection.GridTariff.TariffPrice.PriceInfo;
            return priceInfos;
        }

        [Fact()]
        public void NorwegianSummerTimeTest()
        {
            Setup();
            var startDateTime = new DateTimeOffset(new DateTime(2021, 06, 01, 0, 0, 0), new TimeSpan(2, 0, 0));
            var endDateTime = new DateTimeOffset(new DateTime(2021, 06, 02, 0, 0, 0), new TimeSpan(2, 0, 0));
            var request = new TariffQueryRequestMeteringPoints { MeteringPointIds = new List<string> { "abc1" }, StartTime = startDateTime, EndTime = endDateTime };
            List<PriceInfo> priceInfos = ExecuteRequestAndInitialVerify(request);
            Assert.Equal(24, priceInfos.Count);
            AssertCorrectHours(startDateTime, priceInfos);
            VerifyPriceInfo(startDateTime, priceInfos, "00-01", 0.2515);
            VerifyPriceInfo(startDateTime.AddHours(5), priceInfos, "05-06", 0.2515);
            VerifyPriceInfo(startDateTime.AddHours(6), priceInfos, "06-07", 0.2765);
            VerifyPriceInfo(startDateTime.AddHours(21), priceInfos, "21-22", 0.2765);
            VerifyPriceInfo(startDateTime.AddHours(22), priceInfos, "22-23", 0.2515);
            VerifyPriceInfo(startDateTime.AddHours(23), priceInfos, "23-24", 0.2515);
        }

        private static void AssertCorrectHours(DateTimeOffset startDateTime, List<PriceInfo> priceInfos)
        {
            DateTimeOffset dateIterator = startDateTime;
            while (dateIterator.Day == startDateTime.Day)
            {
                var priceInfoElement = priceInfos.FirstOrDefault(x => x.StartTime == dateIterator);
                Assert.NotNull(priceInfoElement);
                Assert.Equal(priceInfoElement.ExpiredAt, dateIterator.AddHours(1));
                dateIterator = dateIterator.AddHours(1);
            }
        }

        private static void VerifyPriceInfo(DateTimeOffset startDateTime, List<PriceInfo> priceInfos,string hoursShort, double variableprice)
        {
            PriceInfo priceInfoFirst = priceInfos.FirstOrDefault(x => x.StartTime == startDateTime);
            Assert.Equal(priceInfoFirst.ExpiredAt, startDateTime.AddHours(1));
            Assert.Equal(hoursShort, priceInfoFirst.HoursShortName);
            Assert.Equal(variableprice, (double)priceInfoFirst.VariablePrice.Total, 4);
        }
    }
}