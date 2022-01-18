using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Lib.Services;
using GridTariffApi.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace GridTariffApi.Tests.Mdmx.DeveloperAdHocTests
{
    public class TariffPriceCacheDeveloperAdHocTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public TariffPriceCacheDeveloperAdHocTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [DeveloperAdHocFactSkippedUnlessDebugging]
        public async Task TestGetMeteringPointInformation()
        {
            // Manual integration test for the metering point part of TariffPriceCache. Will read tariff from database and maxConsumption from the MDMx API.

            var host = Program.CreateHostBuilder(new string[] { }).Build();

            var tariffPriceCache = host.Services.GetRequiredService<ITariffPriceCache>();

            var mpid = "707057599999990530";

            var mpInformations = await tariffPriceCache.GetMeteringPointInformationsAsync(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, new List<string> { mpid });

            Assert.NotNull(mpInformations);
            var mpInformation = Assert.Single(mpInformations);

            var json = JsonConvert.SerializeObject(mpInformation, Formatting.Indented);
            _outputHelper.WriteLine($"Received metering point information:\n{json}");

            Assert.Equal(mpid, mpInformation.MeteringPointId);
            Assert.True(mpInformation.MaxConsumption > 0); // Usually true, might be false just after a new month has started or if something doesn't work.
            Assert.NotNull(mpInformation.MaxConsumption); // Usually true.

            var loggingDataCollector = host.Services.GetRequiredService<IElviaLoggingDataCollector>();
            _outputHelper.WriteLine($"Call to MDMx took {loggingDataCollector.MdmxElapsedSeconds:0.000} s");
        }
    }
}