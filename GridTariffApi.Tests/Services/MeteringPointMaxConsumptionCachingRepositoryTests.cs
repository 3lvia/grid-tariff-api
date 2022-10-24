using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Mdmx;
using GridTariffApi.Services;
using Moq;
using Xunit;

namespace GridTariffApi.Tests.Services
{
    public class MeteringPointMaxConsumptionCachingRepositoryTests
    {
        [Fact]
        public async Task TestMeteringPointMaxConsumptionsAreCachedOnFirstUse()
        {
            List<string> meteringPointIds = new List<string> { "mp1", "mp2", "mp3" };

            var maxConsumption = 3.0;
            var meteringPointMaxConsumptions = meteringPointIds.Select(mpid => new MeteringPointMaxConsumption
            {
                MeteringPointId = mpid,
                MaxConsumption = maxConsumption,
                LastVolumeEndTime = DateTimeOffset.UtcNow
            }).ToList();
            Mock<IMdmxClient> mdmxClientMock = new Mock<IMdmxClient>();
            mdmxClientMock
                .Setup(x => x.GetMaxConsumptionsAsync(It.IsAny<List<String>>()))
                .ReturnsAsync(meteringPointMaxConsumptions);

            var serviceHelper = new ServiceHelper(GetGridTariffApiConfig());
            var cachingRepository = new MeteringPointMaxConsumptionCachingMdmxRepository(mdmxClientMock.Object, new MeteringPointMaxConsumptionRepositoryConfig
            {
                MaxConsumptionCacheTimeout = TimeSpan.FromHours(1),
                TimeZoneForMonthLimiting = Startup.NorwegianTimeZoneInfo()
            },serviceHelper);

            mdmxClientMock.Verify(x => x.GetMaxConsumptionsAsync(meteringPointIds), Times.Never);

            await cachingRepository.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, meteringPointIds);
            mdmxClientMock.Verify(x => x.GetMaxConsumptionsAsync(meteringPointIds), Times.Once);

            var maxConsumptions = await cachingRepository.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, meteringPointIds);
            mdmxClientMock.Verify(x => x.GetMaxConsumptionsAsync(meteringPointIds), Times.Once);

            foreach (var meteringPointMaxConsumption in maxConsumptions)
            {
                Assert.Equal(maxConsumption, meteringPointMaxConsumption.MaxConsumption);
            }
        }

        [Fact]
        public async Task TestMeteringPointMaxConsumptionsNotAvailableForHistoricPeriod()
        {
            var serviceHelper = new ServiceHelper(GetGridTariffApiConfig());

            var cachingRepository = new MeteringPointMaxConsumptionCachingMdmxRepository(new Mock<IMdmxClient>().Object, new MeteringPointMaxConsumptionRepositoryConfig
            {
                TimeZoneForMonthLimiting = Startup.NorwegianTimeZoneInfo()
            },serviceHelper);

            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Startup.NorwegianTimeZoneInfo());

            var maxConsumptions = await cachingRepository.GetMeteringPointMaxConsumptionsAsync(localNow.Subtract(TimeSpan.FromDays(40)), localNow.Subtract(TimeSpan.FromDays(35)), new List<string>{"mp1", "mp2"});
    
            foreach (var meteringPointMaxConsumption in maxConsumptions)
            {
                Assert.Null(meteringPointMaxConsumption.MaxConsumption);
            }
        }



        private GridTariffApiConfig GetGridTariffApiConfig()
        {
            GridTariffApiConfig gridTariffApiConfig = new GridTariffApiConfig
            {
                MinStartDateAllowedQuery = DateTime.MinValue,
                TimeZoneForQueries = Startup.NorwegianTimeZoneInfo(),
            };
            return gridTariffApiConfig;
        }
    }
}