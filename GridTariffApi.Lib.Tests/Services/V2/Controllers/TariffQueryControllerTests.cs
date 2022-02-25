using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Controllers.v1;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Lib.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;
using GridTariff = GridTariffApi.Lib.Models.PriceStructure.GridTariff;
using TariffType = GridTariffApi.Lib.Models.PriceStructure.TariffType;

namespace GridTariffApi.Lib.Tests.Services.V2.Controllers
{
    public class TariffQueryControllerTests
    {
        TariffQueryController _tariffQueryController;
        private Mock<ITariffRepository> _tariffPeristenceMock;
        private Mock<IHolidayRepository> _holidayPeristenceMock;
        private Mock<ITariffQueryService> _tariffQueryServiceMock;

        private void Setup()
        {
            var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "W. Europe Standard Time" :
                "Europe/Oslo";
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            var gridTariffApiConfig = new GridTariffApiConfig
            {
                MinStartDateAllowedQuery = new DateTime(2020, 01, 01),
                TimeZoneForQueries = norwegianTimeZone
            };

            var serviceHelper = new ServiceHelper(gridTariffApiConfig);

            var tariffType = new TariffType("tariffKey", "product", "", "", "", "", false, DateTimeOffset.MinValue, false, null, 0, null, null);
            var tariffTypes = new List<TariffType>
            {
                tariffType
            };

            var gridTariff = new GridTariff(null, tariffTypes);
            var gridTariffPriceConfiguration = new GridTariffPriceConfiguration(gridTariff);
            var tariffPriceStructureRoot = new TariffPriceStructureRoot(gridTariffPriceConfiguration);

            _tariffPeristenceMock = new Mock<ITariffRepository>();
            _tariffPeristenceMock
                .Setup(x => x.GetTariffPriceStructureAsync())
                .ReturnsAsync(tariffPriceStructureRoot);

            _holidayPeristenceMock = new Mock<IHolidayRepository>();
            _holidayPeristenceMock
                .Setup(x => x.GetHolidaysAsync())
                .ReturnsAsync(new List<Holiday>());

            var tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffPeristenceMock.Object, _holidayPeristenceMock.Object, null, null);

            _tariffQueryServiceMock = new Mock<ITariffQueryService>();
            _tariffQueryServiceMock
                .Setup(x => x.QueryTariffUsingProductKeyAsync("product", DateTimeOffset.MaxValue, DateTimeOffset.MaxValue))
                .ReturnsAsync(new GridTariffCollection());

            _tariffQueryServiceMock
                .Setup(x => x.QueryMeteringPointsTariffsAsync(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),It.IsAny< List<String>>()))
    .           Returns(Task.FromResult(new TariffQueryRequestMeteringPointsResult()));


            var controllerValidationHelper = new ControllerValidationHelper(gridTariffApiConfig, tariffPriceCache, serviceHelper);
            _tariffQueryController = new TariffQueryController(_tariffQueryServiceMock.Object, serviceHelper,null, controllerValidationHelper);
        }


        [Fact]
        public async Task TariffQueryServiceIsCalledTest()
        {
            Setup();
            var request = new TariffQueryRequest()
            {
                TariffKey = "tariffKey",
                StartTime = DateTimeOffset.MaxValue,
                EndTime = DateTimeOffset.MaxValue
            };

            await _tariffQueryController.TariffQuery(request);
            _tariffQueryServiceMock.Verify(x => x.QueryTariffUsingTariffKeyAsync(request.TariffKey, DateTimeOffset.MaxValue, DateTimeOffset.MaxValue), Times.Once);
        }

        [Fact]
        public async Task MeteringPointsTariffQueryIsCalledTest()
        {
            Setup();
            var request = new TariffQueryRequestMeteringPoints()
            {
                StartTime = DateTimeOffset.MaxValue,
                EndTime = DateTimeOffset.MaxValue,
                MeteringPointIds = new List<String> { "mpid1" }
            };

            await _tariffQueryController.MeteringPointsTariffQuery(request);
            _tariffQueryServiceMock.Verify(x => x.QueryMeteringPointsTariffsAsync(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<List<String>>()), Times.Once);

        }
    }
}
