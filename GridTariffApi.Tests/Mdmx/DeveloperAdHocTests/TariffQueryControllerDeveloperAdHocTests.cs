using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Lib.Controllers.v1;
using GridTariffApi.Lib.Interfaces;
using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Services;
using GridTariffApi.Lib.Services.Helpers;
using GridTariffApi.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace GridTariffApi.Tests.Mdmx.DeveloperAdHocTests
{
    public class TariffQueryControllerDeveloperAdHocTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public TariffQueryControllerDeveloperAdHocTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [DeveloperAdHocFactSkippedUnlessDebugging]
        public async Task TestPostMeteringPointsTariffQuery()
        {
            // Manual integration test for calling methods on the controller.

            var host = Program.CreateHostBuilder(new string[] { }).Build();

            var controller = new TariffQueryController(
                host.Services.GetRequiredService<ITariffQueryService>(),
                host.Services.GetRequiredService<IServiceHelper>(),
                host.Services.GetRequiredService<ILoggingDataCollector>(),
                host.Services.GetRequiredService<IControllerValidationHelper>(),
                null);

            var request = new TariffQueryRequestMeteringPoints
            {
                Range = "yesterday",
                StartTime = null,
                EndTime = null,
                MeteringPointIds = new List<string> { "707057599999990530", "707057599999990540" }
            };

            var actionResult = await controller.MeteringPointsTariffQuery(request);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult?.StatusCode);
            var result = okResult?.Value as TariffQueryRequestMeteringPointsResult;
            Assert.NotNull(result);
            Assert.NotEmpty(result?.GridTariffCollections ?? new List<GridTariffCollection>());

            var loggingDataCollector = host.Services.GetRequiredService<IElviaLoggingDataCollector>();
            _outputHelper.WriteLine($"POST MeteringPointsTariffQuery took {loggingDataCollector.MdmxElapsedSeconds:0.000} s");

            _outputHelper.WriteLine($"Result: {JsonConvert.SerializeObject(result)}");
        }
    }
}
