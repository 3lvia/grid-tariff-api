using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services
{
    public class TariffPriceCacheTests
    {
        private Mock<ITariffRepository> _tariffRepositoryMock;
        private Mock<IHolidayRepository> _holidayRepositoryMock;
        private Mock<IMeteringPointTariffRepository> _meteringPointTariffRepository;
        private Mock<IMeteringPointMaxConsumptionRepository> _meteringPointMaxConsumptionRepository;
        private List<string> _meteringPointIds;
        private void Setup(string tariffKey = "standard", double? maxHourlyEnergyConsumption = null)
        {
            _tariffRepositoryMock = new Mock<ITariffRepository>();
            _tariffRepositoryMock
                .Setup(x => x.GetTariffPriceStructure())
                .Returns(new TariffPriceStructureRoot(null));

            _holidayRepositoryMock = new Mock<IHolidayRepository>();
            _holidayRepositoryMock
                .Setup(x => x.GetHolidays())
                .Returns(new List<Holiday>());


            var meteringPointTariffs = new List<MeteringPointTariff>();
            meteringPointTariffs.Add(new MeteringPointTariff("mp1", tariffKey));
            meteringPointTariffs.Add(new MeteringPointTariff("mp2", tariffKey));
            meteringPointTariffs.Add(new MeteringPointTariff("mp3", tariffKey));
            _meteringPointIds = meteringPointTariffs.Select(mpTariff => mpTariff.MeteringPointId).ToList();

            _meteringPointTariffRepository = new Mock<IMeteringPointTariffRepository>();
            _meteringPointTariffRepository
                .Setup(x => x.GetMeteringPointTariffsAsync(It.IsAny<List<String>>()))
                .ReturnsAsync((IReadOnlyList<Models.Internal.MeteringPointTariff>)meteringPointTariffs);

            var meteringPointMaxConsumptions = _meteringPointIds.Select(mpid => new MeteringPointMaxConsumption
            {
                MeteringPointId = mpid,
                MaxHourlyEnergyConsumption = maxHourlyEnergyConsumption,
                LastVolumeEndTime = DateTimeOffset.UtcNow
            }).ToList().AsReadOnly();
            _meteringPointMaxConsumptionRepository = new Mock<IMeteringPointMaxConsumptionRepository>();
            _meteringPointMaxConsumptionRepository
                .Setup(x => x.GetMeteringPointMaxConsumptionsAsync(It.IsAny<List<String>>()))
                .ReturnsAsync((IReadOnlyList<Models.Internal.MeteringPointMaxConsumption>)meteringPointMaxConsumptions);
        }

        [Fact]
        public void TariffRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffRepositoryMock.Object, _holidayRepositoryMock.Object,null, null);

            for (int i = 0; i < 10; i++)
            {
                tariffPriceCache.GetTariffRootElement();
            }
            _tariffRepositoryMock.Verify(x => x.GetTariffPriceStructure(), Times.Once);
        }

        [Fact]
        public void HolidayRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffRepositoryMock.Object, _holidayRepositoryMock.Object,null, null);
            for (int i = 0; i < 10; i++)
            {
                tariffPriceCache.GetHolidays(DateTimeOffset.MinValue,DateTimeOffset.MaxValue);
            }
            _holidayRepositoryMock.Verify(x => x.GetHolidays(), Times.Once);
        }

        [Fact]
        public async Task MeteringPointCacheOnFirstUseTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffRepositoryMock.Object, _holidayRepositoryMock.Object, _meteringPointTariffRepository.Object, _meteringPointMaxConsumptionRepository.Object);

            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Never);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(_meteringPointIds), Times.Never);

            await tariffPriceCache.GetMeteringPointInformationAsync(_meteringPointIds);
            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Once);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(_meteringPointIds), Times.Once);

            await tariffPriceCache.GetMeteringPointInformationAsync(_meteringPointIds);
            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Once);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(_meteringPointIds), Times.Once);
        }

        [Fact]
        public async Task MeteringPointInformationMergedFromMpTariffRepositoryAndMpMaxConsumptionRepositoryTest()
        {
            var tariffKey = "test-tariff";
            var maxConsumption = 33.33;
            Setup(tariffKey, maxConsumption);
            TariffPriceCache tariffPriceCache = new TariffPriceCache(_tariffRepositoryMock.Object, _holidayRepositoryMock.Object, _meteringPointTariffRepository.Object, _meteringPointMaxConsumptionRepository.Object);

            var mpInformations = await tariffPriceCache .GetMeteringPointInformationAsync(_meteringPointIds);

            Assert.NotNull(mpInformations);
            Assert.Equal(_meteringPointIds.Count, mpInformations.Count);
            foreach (var i in Enumerable.Range(0, _meteringPointIds.Count - 1))
            {
                var mpInfo = mpInformations[i];
                Assert.Equal(_meteringPointIds[i], mpInfo.MeteringPointId);
                Assert.Equal(tariffKey, mpInfo.TariffKey);
                Assert.Equal(maxConsumption, mpInfo.MaxConsumption);
            }
        }
    }
}
