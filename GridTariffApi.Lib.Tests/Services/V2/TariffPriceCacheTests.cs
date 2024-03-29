﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using GridTariffApi.Lib.Services;
using Moq;
using Xunit;

namespace GridTariffApi.Lib.Tests.Services.V2
{
    public class TariffPriceCacheTests
    {
        private Mock<ITariffRepository> _tariffRepositoryMock;
        private Mock<IHolidayRepository> _holidayRepositoryMock;
        private Mock<IMeteringPointTariffRepository> _meteringPointTariffRepository;
        private Mock<IMeteringPointMaxConsumptionRepository> _meteringPointMaxConsumptionRepository;
        private List<string> _meteringPointIds;
        private void Setup(string tariffKey = "standard", double? maxConsumption = null)
        {
            _tariffRepositoryMock = new Mock<ITariffRepository>();
            _tariffRepositoryMock
                .Setup(x => x.GetTariffPriceStructureAsync())
                .ReturnsAsync(new TariffPriceStructureRoot(null));

            _holidayRepositoryMock = new Mock<IHolidayRepository>();
            _holidayRepositoryMock
                .Setup(x => x.GetHolidaysAsync())
                .ReturnsAsync(new List<Holiday>());


            var meteringPointTariffs = new List<MeteringPointTariff>
            {
                new MeteringPointTariff("mp1", tariffKey),
                new MeteringPointTariff("mp2", tariffKey),
                new MeteringPointTariff("mp3", tariffKey)
            };
            _meteringPointIds = meteringPointTariffs.Select(mpTariff => mpTariff.MeteringPointId).ToList();

            _meteringPointTariffRepository = new Mock<IMeteringPointTariffRepository>();
            _meteringPointTariffRepository
                .Setup(x => x.GetMeteringPointTariffsAsync(It.IsAny<List<String>>()))
                .ReturnsAsync((IReadOnlyList<Models.Internal.MeteringPointTariff>)meteringPointTariffs);

            var meteringPointMaxConsumptions = _meteringPointIds.Select(mpid => new MeteringPointMaxConsumption
            {
                MeteringPointId = mpid,
                MaxConsumption = maxConsumption,
                LastVolumeEndTime = DateTimeOffset.UtcNow
            }).ToList();
            _meteringPointMaxConsumptionRepository = new Mock<IMeteringPointMaxConsumptionRepository>();
            _meteringPointMaxConsumptionRepository
                .Setup(x => x.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, It.IsAny<List<String>>()))
                .ReturnsAsync(meteringPointMaxConsumptions);
        }

        [Fact]
        public async Task TariffRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffRepositoryMock.Object, _holidayRepositoryMock.Object, null, null);

            for (int i = 0; i < 10; i++)
            {
                await tariffPriceCache.GetTariffRootElementAsync();
            }
            _tariffRepositoryMock.Verify(x => x.GetTariffPriceStructureAsync(), Times.Once);
        }

        [Fact]
        public async Task HolidayRepositoryCalledOnceTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffRepositoryMock.Object, _holidayRepositoryMock.Object, null, null);
            for (int i = 0; i < 10; i++)
            {
                await tariffPriceCache.GetHolidaysAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            }
            _holidayRepositoryMock.Verify(x => x.GetHolidaysAsync(), Times.Once);
        }

        [Fact]
        public async Task MeteringPointMaxConsumptionOncePerInvocationAndTariffOnFirstUseTest()
        {
            Setup();
            TariffPriceCache tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffRepositoryMock.Object, _holidayRepositoryMock.Object, _meteringPointTariffRepository.Object, _meteringPointMaxConsumptionRepository.Object);

            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Never);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds), Times.Never);

            await tariffPriceCache.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds);
            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Once);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds), Times.Once);

            await tariffPriceCache.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds);
            _meteringPointTariffRepository.Verify(x => x.GetMeteringPointTariffsAsync(_meteringPointIds), Times.Once);
            _meteringPointMaxConsumptionRepository.Verify(x => x.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds), Times.Exactly(2));
        }

        [Fact]
        public async Task MeteringPointInformationMergedFromMpTariffRepositoryAndMpMaxConsumptionRepositoryTest()
        {
            var tariffKey = "test-tariff";
            var maxConsumption = 33.33;
            Setup(tariffKey, maxConsumption);
            TariffPriceCache tariffPriceCache = new TariffPriceCache(new TariffPriceCacheDataStore(), _tariffRepositoryMock.Object, _holidayRepositoryMock.Object, _meteringPointTariffRepository.Object, _meteringPointMaxConsumptionRepository.Object);

            var mpInformations = await tariffPriceCache.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, _meteringPointIds);

            Assert.NotNull(mpInformations);
            Assert.Equal(_meteringPointIds.Count, mpInformations.Count);
            foreach (var i in Enumerable.Range(0, _meteringPointIds.Count - 1))
            {
                var mpInfo = mpInformations[i];
                Assert.Equal(_meteringPointIds[i], mpInfo.MeteringPointId);
                Assert.Equal(tariffKey, mpInfo.ProductKey);
                Assert.Equal(maxConsumption, mpInfo.MaxConsumption);
            }
        }
    }
}
