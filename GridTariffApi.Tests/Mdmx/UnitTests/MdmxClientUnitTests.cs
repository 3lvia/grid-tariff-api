using GridTariffApi.Elvid;
using GridTariffApi.Mdmx;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GridTariffApi.Metrics;
using Xunit;

namespace GridTariffApi.Tests.Mdmx.UnitTests
{
    public class MdmxClientUnitTests
    {
        [Fact]
        public async Task TestGetVolumeAggregationsForThisMonth_HappyPath()
        {
            // Cannot mock HttpClient, but its inner HttpMessageHandler can be mocked and only has one method
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandlerMock
                .Protected() // The SendAsync method is protected
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{'meteringPointId':'707057599999990530','min':0,'max':56.52,'sum':142189.23919999308,'lastVolumeEndTime':'2022-01-06T11:00:00+00:00'},{'meteringPointId':'707057599999990540','min':0,'max':0.0147,'sum':53.40549999999888}]", Encoding.UTF8, "application/json")
                })
                .Verifiable();

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var accessTokenServiceMock = new Mock<IMdmxAccessTokenService>();
            accessTokenServiceMock.Setup(service => service.GetAccessToken()).ReturnsAsync("the not so secret token");

            var mdmxClient = new MdmxClient(httpClientFactoryMock.Object, accessTokenServiceMock.Object, new MdmxConfig
                {
                    HostAddress = "https://mdmx.mocked-elvia.no/",
                    TimeZoneForMonthLimiting = Startup.NorwegianTimeZoneInfo()
                },
                new LoggingDataCollector());

            var mpids = new List<string> { "707057599999990530", "707057599999990540" };
            var maxConsumptions = await mdmxClient.GetVolumeAggregationsForThisMonthAsync(mpids);

            httpMessageHandlerMock.Verify();
            accessTokenServiceMock.Verify(service => service.GetAccessToken(), Times.Once);

            Assert.NotNull(maxConsumptions);
            Assert.Equal(2, maxConsumptions.Count);
            var sample1 = maxConsumptions.FirstOrDefault(maxConsumption => maxConsumption.MeteringPointId == "707057599999990530");
            Assert.NotNull(sample1);
            Assert.Equal(DateTimeOffset.Parse("2022-01-06T11:00:00+00:00"), sample1.LastVolumeEndTime);
            Assert.Equal(56.52d, sample1.MaxHourlyEnergyConsumption);
        }
    }
}