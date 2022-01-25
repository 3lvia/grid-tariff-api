using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services;
using GridTariffApi.Lib.Services.Helpers;
using Moq;
using Xunit;
using GridTariff = GridTariffApi.Lib.Models.PriceStructure.GridTariff;
using TariffType = GridTariffApi.Lib.Models.PriceStructure.TariffType;

namespace GridTariffApi.Lib.Tests.Services.Helpers
{
    public class ControllerValidationHelperTests
    {
        private IControllerValidationHelper _controllerValidationHelper;
        private Mock<ITariffRepository> _tariffPeristenceMock;
        private Mock<IHolidayRepository> _holidayPeristenceMock;

        private void Setup()
        {
            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig { MinStartDateAllowedQuery = new DateTime(2020, 11, 01) };
            gridTariffApiConfig.TimeZoneForQueries = NorwegianTimeZoneInfo();

            var tariffType = new TariffType("tariffKey", "product", "", "", "", "", false, DateTimeOffset.MinValue, false, null, 0, null, null);
            var tariffTypes = new List<TariffType>();
            tariffTypes.Add(tariffType);

            var gridTariff = new GridTariff(null, tariffTypes);
            var gridTariffPriceConfiguration = new GridTariffPriceConfiguration(gridTariff);
            var tariffPriceStructureRoot = new TariffPriceStructureRoot(gridTariffPriceConfiguration);

            _tariffPeristenceMock = new Mock<ITariffRepository>();
            _tariffPeristenceMock
                .Setup(x => x.GetTariffPriceStructure())
                .Returns(tariffPriceStructureRoot);

            _holidayPeristenceMock = new Mock<IHolidayRepository>();
            _holidayPeristenceMock
                .Setup(x => x.GetHolidays())
                .Returns(new List<Holiday>());

            var serviceHelper = new ServiceHelper(gridTariffApiConfig);
            var tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffPeristenceMock.Object, _holidayPeristenceMock.Object, null, null);

            _controllerValidationHelper = new ControllerValidationHelper(gridTariffApiConfig, tariffPriceCache, serviceHelper);
        }

        private static TimeZoneInfo NorwegianTimeZoneInfo()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return norwegianTimeZone;
        }


        [Theory]
        [InlineData("", "", "Neither TariffKey nor Product present in request", "")]
        [InlineData("a", "b", "Both TariffKey and Product present in request. These are mutually exclusive", "")]
        [InlineData("", "b", "Tariff with productcode b not found", "")]
        [InlineData("a", "", "TariffType a not found", "")]
        [InlineData("tariffKey", "", "Query before", "31/12/2019 23:15")]
        [InlineData("tariffKey", "", "", "31/12/2021 23:15")]
        [InlineData("", "product", "", "31/12/2021 23:15")]

        public void ValidateRequestInput(string tariffKey, string productKey, string expectedError, string queryStartDateUtc)
        {
            Setup();

            var request = new TariffQueryRequest()
            {
                TariffKey = tariffKey,
                Product = productKey
            };
            if (queryStartDateUtc.Length > 0)
            {
                request.StartTime = DateTime.SpecifyKind(DateTime.ParseExact(queryStartDateUtc, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), DateTimeKind.Utc);
            }

            var result = _controllerValidationHelper.ValidateRequestInput(request);
            Assert.Contains(expectedError, result);
        }

        [Fact]
        public void ValidateTariffQueryRequestInputNull()
        {
            Setup();
            var result = _controllerValidationHelper.ValidateRequestInput((TariffQueryRequest)null);
            Assert.Contains("Missing model", result);
        }

        [Fact]
        public void ValidateTariffQueryRequestMeteringPointInputNull()
        {
            Setup();
            var result = _controllerValidationHelper.ValidateRequestInput((TariffQueryRequestMeteringPoints)null);
            Assert.Contains("Missing model", result);
        }

        [Fact]
        public void ValidateTariffQueryRequestMeteringPointBeforeMinStartAllowed()
        {
            Setup();
            var result = _controllerValidationHelper.ValidateRequestInput(new TariffQueryRequestMeteringPoints
            {
                Range = null,
                StartTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(10000)),
                EndTime = DateTimeOffset.UtcNow,
                MeteringPointIds = new List<string> { "mpid1" }
            });
            Assert.Contains("before", result.ToLower());
        }

        [Fact]
        public void ValidateTariffQueryRequestMeteringPointIdsNone()
        {
            var request = new TariffQueryRequestMeteringPoints { MeteringPointIds = new List<string> { }, Range = "today"};
            var result = request.Validate(new ValidationContext(request)).ToList();
            Assert.Single(result);
            Assert.Contains(result, e => (e.ErrorMessage ?? "").ToLower().Contains("no"));        }

        [Fact]
        public void ValidateTariffQueryRequestMeteringPointIdsAboveLimit()
        {
            var mpids = Enumerable.Range(1, 10_001).Select(i => $"mpid{i}").ToList();
            var request = new TariffQueryRequestMeteringPoints{MeteringPointIds = mpids, Range = "today"};
            var result = request.Validate(new ValidationContext(request)).ToList();
            Assert.Single(result);
            Assert.Contains(result, e => (e.ErrorMessage ?? "").ToLower().Contains("limit"));
        }
        
        [Theory]
        [InlineData("", "", "")]
        [InlineData("tariffKey", "", "tariffKey")]
        [InlineData("", "product", "tariffKey")]
        [InlineData("tariffKey", "product", "tariffKey")]
        [InlineData("", "notfound", "")]

        public void DecideTariffKeyFromInputTest(string tariffKey, string productKey, string expected)
        {
            Setup();
            var request = new TariffQueryRequest()
            {
                TariffKey = tariffKey,
                Product = productKey
            };

            var actual = _controllerValidationHelper.DecideTariffKeyFromInput(request);
            Assert.Equal(expected, actual);
        }
    }
}
