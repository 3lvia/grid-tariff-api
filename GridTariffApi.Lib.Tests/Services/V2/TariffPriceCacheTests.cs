using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.V2.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffPriceCacheTests
    {
        private Mock<ITariffRepository> _tariffPeristenceMock;
        private Mock<IHolidayRepository> _holidayPeristenceMock;
        private Mock<IMeteringPointRepository> _meteringPointRepository;
        private void Setup()
        {
            _tariffPeristenceMock = new Mock<ITariffRepository>();
            _tariffPeristenceMock
                .Setup(x => x.GetTariffPriceStructure())
                .Returns(new TariffPriceStructureRoot(null));

            _holidayPeristenceMock = new Mock<IHolidayRepository>();
            _holidayPeristenceMock
                .Setup(x => x.GetHolidays())
                .Returns(new List<Holiday>());


            var meteringPointInformations = new List<MeteringPointInformation>();
            meteringPointInformations.Add(new MeteringPointInformation("mp1", null, null, DateTimeOffset.MaxValue));
            meteringPointInformations.Add(new MeteringPointInformation("mp2", null, null, DateTimeOffset.MaxValue));
            meteringPointInformations.Add(new MeteringPointInformation("mp3", null, null, DateTimeOffset.MaxValue));

            _meteringPointRepository = new Mock<IMeteringPointRepository>();
            _meteringPointRepository
                .Setup(x => x.GetMeteringPointsInformation(It.IsAny<List<String>>()))
                .Returns((IReadOnlyList<Models.V2.Internal.MeteringPointInformation>)meteringPointInformations);
        }

        [Fact]
        public void TariffRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object,null);

            for (int i = 0; i < 10; i++)
            {
                tariffPriceCache.GetTariffRootElement();
            }
            _tariffPeristenceMock.Verify(x => x.GetTariffPriceStructure(), Times.Once);
        }

        [Fact]
        public void HolidayRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object,null);
            for (int i = 0; i < 10; i++)
            {
                tariffPriceCache.GetHolidays(DateTimeOffset.MinValue,DateTimeOffset.MaxValue);
            }
            _holidayPeristenceMock.Verify(x => x.GetHolidays(), Times.Once);
        }

        [Fact]
        public void InitMeteringPointIndexInitOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object, _meteringPointRepository.Object);

            var reqParam = new List<String>();
            reqParam.Add("mp1");
            _meteringPointRepository.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Never);
            tariffPriceCache.GetMeteringPointInformation(reqParam);
            _meteringPointRepository.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Once);
            tariffPriceCache.GetMeteringPointInformation(reqParam);
            _meteringPointRepository.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Once);
        }
    }
}
