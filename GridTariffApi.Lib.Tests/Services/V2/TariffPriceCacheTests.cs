using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using GridTariffApi.Lib.Services.V2;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffPriceCacheTests
    {
        private Mock<ITariffPersistence> _tariffPeristenceMock;
        private Mock<IHolidayPersistence> _holidayPeristenceMock;
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

        }

        [Fact]
        public void TariffPersistenceCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object);

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
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffPeristenceMock.Object, _holidayPeristenceMock.Object);
            for (int i = 0; i < 10; i++)
            {
                tariffPriceCache.GetHolidays(DateTimeOffset.MinValue,DateTimeOffset.MaxValue);
            }
            _holidayPeristenceMock.Verify(x => x.GetHolidays(), Times.Once);
        }
    }
}
