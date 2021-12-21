using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Controllers.v2;
using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services.V2;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GridTariff = GridTariffApi.Lib.Models.V2.PriceStructure.GridTariff;
using TariffType = GridTariffApi.Lib.Models.V2.PriceStructure.TariffType;

namespace GridTariffApi.Lib.Tests.Services.V2.Controllers
{
    public class TariffQueryControllerTests
    {
        TariffQueryController _tariffQueryController;
        private Mock<ITariffPersistence> _tariffPeristenceMock;
        private Mock<IHolidayPersistence> _holidayPeristenceMock;
        private Mock<ITariffQueryService> _tariffQueryServiceMock;

        private void Setup()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            var gridTariffApiConfig = new GridTariffApiConfig();
            gridTariffApiConfig.MinStartDateAllowedQuery = new DateTime(2020, 01, 01);
            gridTariffApiConfig.TimeZoneForQueries = norwegianTimeZone;

            var serviceHelper = new ServiceHelper(gridTariffApiConfig);

            var tariffType = new TariffType("tariffKey", "product", "", "", "", "", false, DateTimeOffset.MinValue, false, null, 0, null, null);
            var tariffTypes = new List<TariffType>();
            tariffTypes.Add(tariffType);

            var gridTariff = new GridTariff(null, tariffTypes);
            var gridTariffPriceConfiguration = new GridTariffPriceConfiguration(gridTariff);
            var TariffPriceStructureRoot = new TariffPriceStructureRoot(gridTariffPriceConfiguration);

            _tariffPeristenceMock = new Mock<ITariffPersistence>();
            _tariffPeristenceMock
                .Setup(x => x.GetTariffPriceStructure())
                .Returns(TariffPriceStructureRoot);

            _holidayPeristenceMock = new Mock<IHolidayPersistence>();
            _holidayPeristenceMock
                .Setup(x => x.GetHolidays())
                .Returns(new List<Holiday>());

            var tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object,null,null);

            _tariffQueryServiceMock = new Mock<ITariffQueryService>();
            _tariffQueryServiceMock
                .Setup(x => x.QueryTariffAsync("tariffKey", DateTimeOffset.MaxValue, DateTimeOffset.MaxValue))
                .Returns(Task.FromResult(new GridTariffCollection()));

            _tariffQueryController = new TariffQueryController(_tariffQueryServiceMock.Object, serviceHelper, gridTariffApiConfig, tariffPriceCache,null);
        }


        [Fact]
        public async Task ServiceIsCalledTest()
        {
            Setup();
            var request = new TariffQueryRequest()
            {
                TariffKey = "tariffKey",
                StartTime = DateTimeOffset.MaxValue,
                EndTime = DateTimeOffset.MaxValue
            };

            await _tariffQueryController.TariffQuery(request);
            _tariffQueryServiceMock.Verify(x => x.QueryTariffAsync(request.TariffKey, DateTimeOffset.MaxValue, DateTimeOffset.MaxValue), Times.Once);
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

            var result = _tariffQueryController.ValidateRequestInput(request);
            Assert.Contains(expectedError, result);
        }

        [Fact]
        public void ValidateRequestInputNull()
        {
            Setup();
            var result = _tariffQueryController.ValidateRequestInput(null);
            Assert.Contains("Missing model", result);
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

            var actual = _tariffQueryController.DecideTariffKeyFromInput(request);
            Assert.Equal(expected, actual);
        }
    }
}
