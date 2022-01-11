using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Mdmx;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GridTariffApi.Tests.Mdmx.DeveloperAdHocTests
{
    public class MdmxClientDeveloperAdHocTests
    {
        [DeveloperAdHocFactSkippedUnlessDebugging]
        public async Task TestGetVolumeAggregationsFromMdmxWithManyMpidsInQueryString()
        {
            // The MDMx API has a limit of 10000 mpids. But is it possible to send that many ids as query parameters?
            // No, with 10.000 mpids, we get an url larger than 24k characters. Which is too big for UriBuilder, which we use internally. "UriFormatException, Invalid URI: The Uri string is too long."
            // And even with 1000 mpids, the call fails, but then outside our service. "HTTP 414 Request URI Too Long". 325 is OK, 340 fails (= 8333 characters). Seems like there is a limit of about 8000 characters.

            var host = Program.CreateHostBuilder(new string[] { }).Build();

            var mdmxClient = host.Services.GetRequiredService<IMdmxClient>();

            var numMpids = 1; // 10000;

            var mpids = Enumerable.Range(1, numMpids).Select(_ => "707057599999990530").ToList();

            var maxConsumptions = await mdmxClient.GetVolumeAggregationsForThisMonthAsync(mpids);

            Assert.NotNull(maxConsumptions);
            Assert.Equal(numMpids, maxConsumptions.Count);
        }

        [DeveloperAdHocFactSkippedUnlessDebugging]
        public async Task TestGetVolumeAggregationsFromMdmx()
        {
            var host = Program.CreateHostBuilder(new string[] { }).Build();

            var mdmxClient = host.Services.GetRequiredService<IMdmxClient>();

            var mpid = "707057599999990530"; // From the Fairlight-ts measurements range.

            var mpids = new List<string> { mpid };

            var maxConsumptions = await mdmxClient.GetVolumeAggregationsForThisMonthAsync(mpids);

            Assert.NotNull(maxConsumptions);
            var maxConsumption = Assert.Single(maxConsumptions);
            Assert.Equal(mpid, maxConsumption.MeteringPointId);
            Assert.True(maxConsumption.MaxHourlyEnergyConsumption > 0); // Usually true, might be false just after a new month has started or if something doesn't work.
            Assert.NotNull(maxConsumption.LastVolumeEndTime); // Usually true.
        }
    }
}