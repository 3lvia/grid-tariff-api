using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Internal;
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
                MaxHourlyEnergyConsumption = maxConsumption,
                LastVolumeEndTime = DateTimeOffset.UtcNow
            }).ToList();
            Mock<IMdmxClient> mdmxClientMock = new Mock<IMdmxClient>();
            mdmxClientMock
                .Setup(x => x.GetVolumeAggregationsForThisMonthAsync(It.IsAny<List<String>>()))
                .ReturnsAsync(meteringPointMaxConsumptions);

            var cachingRepository = new MeteringPointMaxConsumptionCachingMdmxRepository(mdmxClientMock.Object, new MeteringPointMaxConsumptionRepositoryConfig
            {
                MaxConsumptionCacheTimeout = TimeSpan.FromHours(1),
                TimeZoneForMonthLimiting = Startup.NorwegianTimeZoneInfo()
            });

            mdmxClientMock.Verify(x => x.GetVolumeAggregationsForThisMonthAsync(meteringPointIds), Times.Never);

            await cachingRepository.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, meteringPointIds);
            mdmxClientMock.Verify(x => x.GetVolumeAggregationsForThisMonthAsync(meteringPointIds), Times.Once);

            var maxConsumptions = await cachingRepository.GetMeteringPointMaxConsumptionsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, meteringPointIds);
            mdmxClientMock.Verify(x => x.GetVolumeAggregationsForThisMonthAsync(meteringPointIds), Times.Once);

            foreach (var meteringPointMaxConsumption in maxConsumptions)
            {
                Assert.Equal(maxConsumption, meteringPointMaxConsumption.MaxHourlyEnergyConsumption);
            }
        }

        [Fact]
        public void TestMaxConsumptionIsValidForPeriodOnlyIfIncludingAnyPartOfCurrentMonth()
        {
            var cachingRepository = new MeteringPointMaxConsumptionCachingMdmxRepository(new Mock<IMdmxClient>().Object, new MeteringPointMaxConsumptionRepositoryConfig
            {
                TimeZoneForMonthLimiting= Startup.NorwegianTimeZoneInfo()
            });

            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Startup.NorwegianTimeZoneInfo());
            
            Assert.True(cachingRepository.MaxConsumptionIsValidForPeriod(localNow, localNow.AddHours(1)));
            Assert.True(cachingRepository.MaxConsumptionIsValidForPeriod(localNow.Subtract(TimeSpan.FromDays(7)), localNow));
            Assert.True(cachingRepository.MaxConsumptionIsValidForPeriod(localNow.Subtract(TimeSpan.FromDays(3)), localNow.AddDays(17)));

            Assert.False(cachingRepository.MaxConsumptionIsValidForPeriod(localNow.Subtract(TimeSpan.FromDays(40)), localNow.Date.Subtract(TimeSpan.FromDays(35))));
            Assert.False(cachingRepository.MaxConsumptionIsValidForPeriod(localNow.Date.Add(TimeSpan.FromDays(35)), localNow.AddDays(40)));
        }  
        
        [Fact]
        public async Task TestMeteringPointMaxConsumptionsNotAvailableForHistoricPeriod()
        {
            var cachingRepository = new MeteringPointMaxConsumptionCachingMdmxRepository(new Mock<IMdmxClient>().Object, new MeteringPointMaxConsumptionRepositoryConfig
            {
                TimeZoneForMonthLimiting = Startup.NorwegianTimeZoneInfo()
            });

            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Startup.NorwegianTimeZoneInfo());

            var maxConsumptions = await cachingRepository.GetMeteringPointMaxConsumptionsAsync(localNow.Subtract(TimeSpan.FromDays(40)), localNow.Subtract(TimeSpan.FromDays(35)), new List<string>{"mp1", "mp2"});
    
            foreach (var meteringPointMaxConsumption in maxConsumptions)
            {
                Assert.Null(meteringPointMaxConsumption.MaxHourlyEnergyConsumption);
            }
        }
    }
}