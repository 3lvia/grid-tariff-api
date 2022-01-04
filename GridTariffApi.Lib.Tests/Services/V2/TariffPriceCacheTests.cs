using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.Internal;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using GridTariffApi.Lib.Services.V2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffPriceCacheTests
    {
        private Mock<ITariffPersistence> _tariffPeristenceMock;
        private Mock<IHolidayPersistence> _holidayPeristenceMock;
        private Mock<IMeteringPointPersistence> _meteringPointPersistence;
        private void Setup()
        {
            _tariffPeristenceMock = new Mock<ITariffPersistence>();
            _tariffPeristenceMock
                .Setup(x => x.GetTariffPriceStructure())
                .Returns(new TariffPriceStructureRoot(null));

            _holidayPeristenceMock = new Mock<IHolidayPersistence>();
            _holidayPeristenceMock
                .Setup(x => x.GetHolidays())
                .Returns(new List<Holiday>());


            var meteringPointInformations = new List<MeteringPointInformation>();
            meteringPointInformations.Add(new MeteringPointInformation("mp1", null, null));
            meteringPointInformations.Add(new MeteringPointInformation("mp2", null, null));
            meteringPointInformations.Add(new MeteringPointInformation("mp3", null, null));

            _meteringPointPersistence = new Mock<IMeteringPointPersistence>();
            _meteringPointPersistence
                .Setup(x => x.GetMeteringPointsInformation(It.IsAny<List<String>>()))
                .Returns((IReadOnlyList<Models.V2.Internal.MeteringPointInformation>)meteringPointInformations);
        }

        [Fact]
        public void TariffPersistenceCalledOnceTest()
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
        public void HolidayPersistenceCalledOnceTest()
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
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object, _meteringPointPersistence.Object);

            var reqParam = new List<String>();
            reqParam.Add("mp1");
            _meteringPointPersistence.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Never);
            tariffPriceCache.GetMeteringPointInformation(reqParam);
            _meteringPointPersistence.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Once);
            tariffPriceCache.GetMeteringPointInformation(reqParam);
            _meteringPointPersistence.Verify(x => x.GetMeteringPointsInformation(reqParam), Times.Once);
        }

        [Theory]
        [InlineData("", "", "", "", 0)]
        [InlineData("mp1", "", "", "", 1)]
        [InlineData("mp1", "mp2", "", "", 2)]
        [InlineData("mp1", "mp2", "mp3", "", 3)]
        [InlineData("mp1", "mp2", "mp3", "mp4", 3)]
        public void GetMeteringPointInformationTest(string firstId, string secondId, string thirdId, string fourthId, int numExpected)
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object, _meteringPointPersistence.Object);

            var param = new List<String>();
            param.Add(firstId);
            param.Add(secondId);
            param.Add(thirdId);
            param.Add(fourthId);
            param.RemoveAll(a => a == "");

            var retVal = tariffPriceCache.GetMeteringPointInformation(param);
            Assert.Equal(numExpected, retVal.Count);

            if (firstId != "")
            {
                Assert.NotNull(retVal.FirstOrDefault(x => x.MeteringPointId == firstId));
            }

            if (secondId != "")
            {
                Assert.NotNull(retVal.FirstOrDefault(x => x.MeteringPointId == secondId));
            }

            if (thirdId != "")
            {
                Assert.NotNull(retVal.FirstOrDefault(x => x.MeteringPointId == thirdId));
            }
            if (fourthId != "")
            {
                Assert.Null(retVal.FirstOrDefault(x => x.MeteringPointId == fourthId));
            }
        }
    }
}
