using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Models.TariffQuery;
using GridTariffApi.Lib.Services.TariffQuery;
using GridTariffApi.Lib.Services.TariffType;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GridTariffApi.Services.TariffQuery.Tests
{
    public class TariffQueryServiceTests
    {
        private TariffQueryService _TariffQueryService;

        private TariffTypeService _tariffTypeService;
        private TariffContext _tariffContext;

        private void Setup()
        {
            var services = new ServiceCollection();
            var db = Guid.NewGuid().ToString();
            services.AddDbContext<TariffContext>(u => u.UseInMemoryDatabase(databaseName: db));

            var provider = services.BuildServiceProvider();
            _tariffContext = provider.GetRequiredService<TariffContext>();
            _TariffQueryService = new TariffQueryService(_tariffContext);
            _tariffTypeService = new TariffTypeService(_tariffContext);
            TestHelper testHelper = new TestHelper();
            _tariffContext.Add(testHelper.GetCompanyElvia());
            _tariffContext.Add(testHelper.GetCompanyFoobar());

            _tariffContext.Add(testHelper.GetTariffRush());
            GridTariffApi.Lib.EntityFramework.TariffType dayNight = testHelper.GetTariffDayNight();
            dayNight.CompanyId = 2;
            _tariffContext.Add(dayNight);

            _tariffContext.AddRange(testHelper.GetUoms());
            _tariffContext.AddRange(testHelper.GetSeasons());
            _tariffContext.AddRange(testHelper.GetPublicHolidays());
            _tariffContext.AddRange(testHelper.GetPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPriceConfigs());
            _tariffContext.AddRange(testHelper.GetVariablePriceConfigs());
            _tariffContext.AddRange(testHelper.GetMeteringPointProducts());
            _tariffContext.SaveChanges();
        }

        [Fact()]
        public void QueryTariffsByMeteringPointsTest()
        {
            Setup();

            var meteringPoints = new List<string>(){"abc1", "abc21", "abc22", "abc23","abc3"};
            var result = _TariffQueryService.QueryTariff(meteringPoints, new DateTime(2021, 01, 01), new DateTime(2021, 01, 02));
            Assert.Equal(2, result.GridTariffCollections.Count);

            var gridTariffCollection1 = result.GridTariffCollections.FirstOrDefault(x => x.GridTariff.TariffType.TariffKey.Equals("private_tou_rush"));
            Assert.NotNull(gridTariffCollection1);
            Assert.Equal(2, gridTariffCollection1.MeteringPoints.Count);
            Assert.Contains("abc1", gridTariffCollection1.MeteringPoints);
            Assert.Contains("abc3", gridTariffCollection1.MeteringPoints);

            var gridTariffCollection2 = result.GridTariffCollections.FirstOrDefault(x => x.GridTariff.TariffType.TariffKey.Equals("private_tou_daynight"));
            Assert.NotNull(gridTariffCollection2);
            Assert.Equal(3, gridTariffCollection2.MeteringPoints.Count);
            Assert.Contains("abc21", gridTariffCollection2.MeteringPoints);
            Assert.Contains("abc22", gridTariffCollection2.MeteringPoints);
            Assert.Contains("abc23", gridTariffCollection2.MeteringPoints);
        }

        [Fact()]
        public void SeasonTest()
        {
            Setup();
            DateTime startDate = new DateTime(2021, 03, 31);
            DateTime endDate = new DateTime(2021, 04, 01, 23, 59, 59);

            Season SeasonWinter = _tariffContext.Season.Where(s => s.Id == 5).FirstOrDefault();
            Season SeasonSummer = _tariffContext.Season.Where(s => s.Id == 2).FirstOrDefault();

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            var priceinfosMarch = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 3);
            Assert.Equal(24, priceinfosMarch.Count());
            Assert.Equal(24, priceinfosMarch.Count(f => f.Season.Equals(SeasonWinter.Description)));

            var priceinfosApril = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 4);
            Assert.Equal(24, priceinfosApril.Count());
            Assert.Equal(24, priceinfosApril.Count(f => f.Season.Equals(SeasonSummer.Description)));
        }

        [Fact()]
        public void SeasonPublicHolidayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2021, 01, 02, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count(f => f.StartTime.Month == 12 && !f.PublicHoliday));
            Assert.Empty(result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 12 && f.PublicHoliday));

            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count(f => f.StartTime.Month == 1 && f.StartTime.Day == 1 && f.PublicHoliday));
            Assert.Empty(result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 1 && !f.PublicHoliday));

            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count(f => f.StartTime.Month == 1 && f.StartTime.Day == 2 && !f.PublicHoliday));
            Assert.Empty(result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 2 && f.PublicHoliday));
        }

        [Fact()]
        public void StartTimeEndTimeTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count);

            for (int hour = 0; hour < 24; hour++)
            {
                PriceInfo priceInfo =
                result.GridTariff.TariffPrice.PriceInfo.FirstOrDefault(f => f.StartTime.Date == startDate.Date && f.StartTime.Hour == hour);
                Assert.NotNull(priceInfo);
                Assert.Equal(0, priceInfo.StartTime.Minute);
                Assert.Equal(0, priceInfo.StartTime.Second);
                Assert.Equal(0, priceInfo.StartTime.Millisecond);
                if (hour < 23)
                {
                    Assert.Equal(priceInfo.StartTime.Date, priceInfo.ExpiredAt.Date);
                    Assert.Equal(priceInfo.ExpiredAt.Hour, priceInfo.StartTime.Hour + 1);
                }
                else
                {
                    Assert.Equal(priceInfo.StartTime.Date.AddDays(1), priceInfo.ExpiredAt.Date);
                    Assert.Equal(0, priceInfo.ExpiredAt.Hour);
                }
                Assert.Equal(0, priceInfo.ExpiredAt.Minute);
                Assert.Equal(0, priceInfo.ExpiredAt.Second);
                Assert.Equal(0, priceInfo.ExpiredAt.Millisecond);
            }
        }

        [Fact()]
        public void AFewHoursTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31, 6, 30, 0);
            DateTime endDate = new DateTime(2020, 12, 31, 7, 30, 0);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.Equal(2, result.GridTariff.TariffPrice.PriceInfo.Count);

            for (int hour = 6; hour < 8; hour++)
            {
                PriceInfo priceInfo =
                result.GridTariff.TariffPrice.PriceInfo.FirstOrDefault(f => f.StartTime.Date == startDate.Date && f.StartTime.Hour == hour);
                Assert.NotNull(priceInfo);
                Assert.Equal(hour, priceInfo.StartTime.Hour);
                Assert.Equal(priceInfo.StartTime.Hour + 1, priceInfo.ExpiredAt.Hour);
                Assert.False(priceInfo.PublicHoliday);
                Assert.Equal("winter", priceInfo.Season);

                Assert.Equal("NOK", priceInfo.VariablePrice.Currency);
                Assert.Equal(0.3274M, priceInfo.VariablePrice.Energy);
                Assert.Equal("NORMAL", priceInfo.VariablePrice.Level);
                Assert.Equal(0M, priceInfo.VariablePrice.Power);
                Assert.Equal(.2531M, priceInfo.VariablePrice.Taxes);
                Assert.Equal(.5805M, priceInfo.VariablePrice.Total);
                Assert.Equal("kr/kWh", priceInfo.VariablePrice.Uom);

                Assert.Equal("NOK", priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Currency);
                Assert.Equal(.2151M, priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Fixed);
                Assert.Equal("Level2", priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Level);
                Assert.Equal("For alle privatkunder i Elvia med tariff: Nettleie Rush&Ro eller Nettleie Dag&Natt", priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().LevelInfo);
                Assert.Equal(.0538M, priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Taxes);
                Assert.Equal(.2689M, priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Total);
                Assert.Equal("kr/hour", priceInfo.FixedPrices.FirstOrDefault().PriceLevel.FirstOrDefault().Uom);
            }
        }

        [Fact()]
        public void HoursShortNameTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count);
            foreach (var priceInfo in result.GridTariff.TariffPrice.PriceInfo)
            {
                int hour = priceInfo.StartTime.Hour;
                String hoursShortName = $"{hour.ToString().PadLeft(2, '0')}-{(hour + 1).ToString().PadLeft(2, '0')}";
                Assert.Equal(priceInfo.HoursShortName, hoursShortName);
            }
        }

        [Fact()]
        public void VariablePriceSaturdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 26);
            DateTime endDate = new DateTime(2020, 12, 26, 23, 59, 59);
            ValidateWeekend(startDate, endDate);
        }

        [Fact()]
        public void VariablePriceSundayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 27);
            DateTime endDate = new DateTime(2020, 12, 27, 23, 59, 59);
            ValidateWeekend(startDate, endDate);
        }


        private void ValidateWeekend(DateTime startDate, DateTime endDate)
        {
            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            VariablePriceConfig variablePriceConfig = _tariffContext.VariablePriceconfig.Where(f => f.TariffTypeDd == 1 && f.MonthNo == 12).OrderBy(f => f.PriceLevel.SortOrder)
                .FirstOrDefault();
            Assert.NotNull(variablePriceConfig);

            for (int hour = 0; hour < 24; hour++)
            {
                PriceInfo priceInfo = result.GridTariff.TariffPrice.PriceInfo.FirstOrDefault(f => f.StartTime.Hour == hour);
                Assert.NotNull(priceInfo);
                Assert.Equal(variablePriceConfig.Total, priceInfo.VariablePrice.Total);
                Assert.Equal(variablePriceConfig.Energy, priceInfo.VariablePrice.Energy);
                Assert.Equal(variablePriceConfig.Power, priceInfo.VariablePrice.Power);
                Assert.Equal(priceInfo.VariablePrice.Taxes,
                    (variablePriceConfig.TaxEnova + variablePriceConfig.TaxEnergy + variablePriceConfig.TaxMva));
                Assert.Equal(variablePriceConfig.PriceLevel.PriceLevelDescription, priceInfo.VariablePrice.Level);
                Assert.Equal(variablePriceConfig.Uom.Currency, priceInfo.VariablePrice.Currency);
                Assert.Equal(variablePriceConfig.Uom.Unit, priceInfo.VariablePrice.Uom);
            }
        }

        [Fact()]
        public void VariablePriceWorkdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            List<VariablePriceConfig> variablePriceConfigs = _tariffContext.VariablePriceconfig.Where(f => f.TariffTypeDd == 1 && f.MonthNo == 12)
                .ToList();
            Assert.Equal(3, variablePriceConfigs.Count);

            foreach (var variablePriceConfig in variablePriceConfigs)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);

                for (int i = 0; i < configHours.Count(); i++)
                {
                    int hour = configHours.ElementAt(i);
                    PriceInfo priceInfo = result.GridTariff.TariffPrice.PriceInfo.FirstOrDefault(f => f.StartTime.Hour == hour);
                    Assert.NotNull(priceInfo);
                    Assert.Equal(variablePriceConfig.Total, priceInfo.VariablePrice.Total);
                    Assert.Equal(variablePriceConfig.Energy, priceInfo.VariablePrice.Energy);
                    Assert.Equal(variablePriceConfig.Power, priceInfo.VariablePrice.Power);
                    Assert.Equal(priceInfo.VariablePrice.Taxes,
                        (variablePriceConfig.TaxEnova + variablePriceConfig.TaxEnergy + variablePriceConfig.TaxMva));
                    Assert.Equal(variablePriceConfig.PriceLevel.PriceLevelDescription, priceInfo.VariablePrice.Level);
                    Assert.Equal(variablePriceConfig.Uom.Currency, priceInfo.VariablePrice.Currency);
                    Assert.Equal(variablePriceConfig.Uom.Unit, priceInfo.VariablePrice.Uom);
                }
            }
        }

        [Fact()]
        public void FixedPriceWorkdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            int hoursInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month) * 24;
            const int uomID = 4;        //kr/hour

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.Equal(24, result.GridTariff.TariffPrice.PriceInfo.Count);

            UnitOfMeasure uomKrHour = _tariffContext.Uom.Where(f => f.Id == uomID).FirstOrDefault();
            Assert.NotNull(uomKrHour);

            List<FixedPriceConfig> fixedPriceConfigs = _tariffContext.FixedPriceConfig.Where(f => f.TariffTypeId == 1 && f.MonthNo == 12).ToList();
            Assert.Single(fixedPriceConfigs);

            foreach (var fixedPriceConfig in fixedPriceConfigs)
            {
                foreach (var priceInfo in result.GridTariff.TariffPrice.PriceInfo)
                {
                    foreach (var fixedPrices in priceInfo.FixedPrices)
                    {
                        foreach (var priceLevel in fixedPrices.PriceLevel)
                        {
                            Decimal fixedVal = Decimal.Round(fixedPriceConfig.Fixed / hoursInMonth, 4);
                            Decimal taxesVal = Decimal.Round(fixedPriceConfig.Taxes / hoursInMonth, 4);
                            Decimal totalVal = fixedVal + taxesVal;

                            Assert.Equal(priceLevel.Level, fixedPriceConfig.PriceLevel.PriceLevel);
                            Assert.Equal(priceLevel.LevelInfo, fixedPriceConfig.PriceLevel.LevelInfo);
                            Assert.Equal(priceLevel.Currency, fixedPriceConfig.Uom.Currency);
                            Assert.Equal(priceLevel.Uom, uomKrHour.Unit);
                            Assert.Equal(priceLevel.Fixed, fixedVal);
                            Assert.Equal(priceLevel.Taxes, taxesVal);
                            Assert.Equal(priceLevel.Total, totalVal);
                        }
                    }
                }
            }
        }
        [Fact()]
        public void LargeQueryTest()
        {
            const int numDays = 365;
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = startDate.AddDays(numDays).AddMinutes(-1);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.NotNull(result);
            Assert.NotNull(result.GridTariff);
            Assert.NotNull(result.GridTariff.TariffType);
            Assert.NotNull(result.GridTariff.TariffPrice);
            Assert.NotNull(result.GridTariff.TariffPrice.PriceInfo);
            Assert.Equal(numDays * 24, result.GridTariff.TariffPrice.PriceInfo.Count);

            foreach (var priceInfo in result.GridTariff.TariffPrice.PriceInfo)
            {
                Assert.NotNull(priceInfo.FixedPrices);
                Assert.Single(priceInfo.FixedPrices);
                Assert.NotNull(priceInfo.FixedPrices.FirstOrDefault());
                Assert.NotNull(priceInfo.VariablePrice);
            }
        }

        [Fact()]
        public void ChangeInFixedTariffTest()
        {
            Setup();
            DateTime startDate = new DateTime(2024, 12, 27);
            DateTime endDate = new DateTime(2025, 01, 03).AddMinutes(-1);

            FixedPriceConfig fixedpriceconfigFirst = _tariffContext.FixedPriceConfig.Where(f => f.TariffTypeId == 1 && f.MonthNo == 12 && f.PriceFromDate.Year < endDate.Year).FirstOrDefault();
            FixedPriceConfig fixedpriceconfigLast = _tariffContext.FixedPriceConfig.Where(f => f.TariffTypeId == 1 && f.MonthNo == 1 && f.PriceFromDate.Year == endDate.Year).FirstOrDefault();
            Assert.NotNull(fixedpriceconfigFirst);
            Assert.NotNull(fixedpriceconfigLast);


            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            DateTime dateIterator = startDate;
            while (dateIterator.Date <= endDate.Date)
            {
                int hoursInMonth = DateTime.DaysInMonth(dateIterator.Year, dateIterator.Month) * 24;

                List<PriceInfo> priceInfos = result.GridTariff.TariffPrice.PriceInfo.Where(p => p.StartTime.Date.Equals(dateIterator.Date)).ToList();
                Assert.Equal(24, priceInfos.Count);

                Decimal fixedVal;
                Decimal taxesVal;
                Decimal totalVal;
                if (dateIterator.Year == fixedpriceconfigFirst.PriceToDate.Year)
                {
                    fixedVal = Decimal.Round(fixedpriceconfigFirst.Fixed / hoursInMonth, 4);
                    taxesVal = Decimal.Round(fixedpriceconfigFirst.Taxes / hoursInMonth, 4);
                    totalVal = fixedVal + taxesVal;
                }
                else
                {
                    fixedVal = Decimal.Round(fixedpriceconfigLast.Fixed / hoursInMonth, 4);
                    taxesVal = Decimal.Round(fixedpriceconfigLast.Taxes / hoursInMonth, 4);
                    totalVal = fixedVal + taxesVal;
                }

                foreach (var priceInfo in priceInfos)
                {
                    Assert.Single(priceInfo.FixedPrices);
                    FixedPrices fixedPrice = priceInfo.FixedPrices.FirstOrDefault();
                    Assert.Single(fixedPrice.PriceLevel);
                    GridTariffApi.Lib.Models.TariffQuery.PriceLevel priceLevel = fixedPrice.PriceLevel.FirstOrDefault();

                    Assert.Equal(fixedVal, priceLevel.Fixed);
                    Assert.Equal(taxesVal, priceLevel.Taxes);
                    Assert.Equal(totalVal, priceLevel.Total);

                }
                dateIterator = dateIterator.AddDays(1);
            }
        }

        [Fact()]
        public void ChangeInVariableTariffTest()
        {
            Setup();
            DateTime startDate = new DateTime(2024, 12, 27);
            DateTime endDate = new DateTime(2025, 01, 05).AddMinutes(-1);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            DateTime dateIterator = startDate;
            while (dateIterator.Date <= endDate.Date)
            {
                List<VariablePriceConfig> variablePriceConfigs = _tariffContext.VariablePriceconfig.Where(v => v.PriceFromDate.Date <= dateIterator.Date
                && v.PriceToDate >= dateIterator.Date
                && v.MonthNo == dateIterator.Month
                && v.TariffTypeDd == 1).ToList();

                List<PriceInfo> priceInfos = result.GridTariff.TariffPrice.PriceInfo.Where(p => p.StartTime.Date.Equals(dateIterator.Date)).ToList();
                Assert.Equal(24, priceInfos.Count);

                bool isHoliday = dateIterator.DayOfWeek == DayOfWeek.Saturday || dateIterator.DayOfWeek == DayOfWeek.Sunday;
                if (isHoliday)
                {
                    VariablePriceConfig lowPriceVariablePriceConfig = variablePriceConfigs.OrderBy(v => v.PriceLevel.SortOrder).FirstOrDefault();
                    Assert.NotNull(lowPriceVariablePriceConfig);
                    Assert.Equal(24, priceInfos.Count(p => p.VariablePrice.Energy.Equals(lowPriceVariablePriceConfig.Energy)));
                    Assert.Equal(24, priceInfos.Count(p => p.VariablePrice.Power.Equals(lowPriceVariablePriceConfig.Power)));
                    Assert.Equal(24, priceInfos.Count(p => p.VariablePrice.Total.Equals(lowPriceVariablePriceConfig.Total)));

                }
                else
                {
                    int ctr = 0;
                    foreach (var variablePriceConfig in variablePriceConfigs)
                    {
                        IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);
                        for (int i = 0; i < configHours.Count(); i++)
                        {
                            int hour = configHours.ElementAt(i);
                            PriceInfo priceInfo = priceInfos.FirstOrDefault(f => f.StartTime.Hour == hour);
                            Assert.NotNull(priceInfo);
                            Assert.Equal(variablePriceConfig.Total, priceInfo.VariablePrice.Total);
                            Assert.Equal(variablePriceConfig.Energy, priceInfo.VariablePrice.Energy);
                            Assert.Equal(variablePriceConfig.Power, priceInfo.VariablePrice.Power);
                            Assert.Equal(priceInfo.VariablePrice.Taxes,
                            (variablePriceConfig.TaxEnova + variablePriceConfig.TaxEnergy + variablePriceConfig.TaxMva));
                            Assert.Equal(variablePriceConfig.PriceLevel.PriceLevelDescription, priceInfo.VariablePrice.Level);
                            Assert.Equal(variablePriceConfig.Uom.Currency, priceInfo.VariablePrice.Currency);
                            Assert.Equal(variablePriceConfig.Uom.Unit, priceInfo.VariablePrice.Uom);
                            ctr++;

                            if (dateIterator.Year == startDate.Year)
                            {
                                Assert.True(1 > priceInfo.VariablePrice.Total);
                                Assert.True(1 > priceInfo.VariablePrice.Energy);
                                Assert.True(1 > priceInfo.VariablePrice.Taxes);
                            }
                            else
                            {
                                Assert.True(1 < priceInfo.VariablePrice.Total);
                                Assert.True(1 < priceInfo.VariablePrice.Energy);
                                Assert.True(1 < priceInfo.VariablePrice.Taxes);
                            }
                        }
                    }
                    Assert.Equal(24, ctr);
                }
                dateIterator = dateIterator.AddDays(1);
            }
        }
    }
}