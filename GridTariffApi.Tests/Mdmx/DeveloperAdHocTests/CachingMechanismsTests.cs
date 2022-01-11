using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GridTariffApi.Lib.Models.Internal;
using Microsoft.Extensions.Caching.Memory;
using Xunit;
using Xunit.Abstractions;

namespace GridTariffApi.Tests.Mdmx.DeveloperAdHocTests
{
    public class CachingMechanismsTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public CachingMechanismsTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [DeveloperAdHocFactSkippedUnlessDebugging]
        public void TestLookupPerformanceWithDictionary()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var dict = new Dictionary<string, MeteringPointInformation>(1000000);
            var mpids = MeteringPointIds();
            foreach (var mpid in mpids)
            {
                dict[mpid] = new MeteringPointInformation(mpid, "", null, null);
            }
            _outputHelper.WriteLine($"Building dict with {dict.Count} elements: {stopwatch.ElapsedMilliseconds} ms");

            Assert.Equal(mpids.Count, dict.Count); // Sonarcloud vil gjerne ha minst 1 Assert

            stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var mpid in mpids)
            {
                // Similar to as in GetMeteringPointTariffsAsync
                var lookup = dict.Where(a => (new[] {mpid}).Contains(a.Key)).First().Value;
            }
            _outputHelper.WriteLine($"Lookup {dict.Count} elements in dict with Where: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var mpid in mpids)
            {
                var lookup = dict[mpid];
            }
            _outputHelper.WriteLine($"Lookup {dict.Count} elements in dict with [index]: {stopwatch.ElapsedMilliseconds} ms");
        }

        [DeveloperAdHocFactSkippedUnlessDebugging]
        public void TestLookupPerformanceWithMemoryCache()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var memCache = new MemoryCache(new MemoryCacheOptions());
            var mpids = MeteringPointIds();
            foreach (var mpid in mpids)
            {
                memCache.Set(mpid, new MeteringPointInformation(mpid, null, null, null), TimeSpan.FromHours(1));
            }
            _outputHelper.WriteLine($"Building MemoryCache with {mpids.Count} elements: {stopwatch.ElapsedMilliseconds} ms");

            Assert.Equal(mpids.Count, memCache.Count); // Sonarcloud vil gjerne ha minst 1 Assert

            stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var mpid in mpids)
            {
                memCache.TryGetValue(mpid, out var lookupResult);
            }
            _outputHelper.WriteLine($"Lookup {mpids.Count} elements in MemoryCache: {stopwatch.ElapsedMilliseconds} ms");
        }

        private List<string> MeteringPointIds()
        {
            return Enumerable.Range(0, 100000).Select(i => (707057590000000000 + i).ToString()).ToList();
        }
    }
}
