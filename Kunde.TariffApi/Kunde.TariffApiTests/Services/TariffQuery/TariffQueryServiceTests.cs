using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kunde.TariffApi.Services.TariffQuery;
using System;
using System.Collections.Generic;
using System.Text;
using Elvia.Telemetry;
using Moq;
using Kunde.TariffApi.Services.TariffType;
using Kunde.TariffApi.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Kunde.TariffApiTests;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Kunde.TariffApi.Models.TariffQuery;
using System.Xml.Schema;

namespace Kunde.TariffApi.Services.TariffQuery.Tests
{
    [TestClass()]
    public class TariffQueryServiceTests
    {
        private Mock<ITelemetryInsightsLogger> _mockLogger;
        private TariffQueryService _TariffQueryService;

        private TariffTypeService _tariffTypeService;
        private TariffContext _tariffContext;

        private void Setup()
        {
            _mockLogger = new Mock<ITelemetryInsightsLogger>();
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
            Tarifftype dayNight = testHelper.GetTariffDayNight();
            dayNight.Companyid = 2;
            _tariffContext.Add(dayNight);

            _tariffContext.AddRange(testHelper.GetUoms());
            _tariffContext.AddRange(testHelper.GetSeasons());
            _tariffContext.AddRange(testHelper.GetPublicHolidays());
            _tariffContext.AddRange(testHelper.GetPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPricelevels());
            _tariffContext.AddRange(testHelper.GetFixedPriceConfigs());
            _tariffContext.AddRange(testHelper.GetVariablePriceConfigs());
            _tariffContext.SaveChanges();
        }

        [TestMethod()]
        public void SeasonTest()
        {
            Setup();
            DateTime startDate = new DateTime(2021, 03, 31);
            DateTime endDate = new DateTime(2021, 04, 01,23,59,59);

            Season SeasonWinter = _tariffContext.Season.Where(s => s.Id == 5).FirstOrDefault();
            Season SeasonSummer = _tariffContext.Season.Where(s => s.Id == 2).FirstOrDefault();

            var result = _TariffQueryService.QueryTariff("private_tou_rush",startDate,endDate);

            var priceinfosMarch = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 3);
            Assert.AreEqual(24, priceinfosMarch.Count());
            Assert.AreEqual(24, priceinfosMarch.Where(f => f.Season.Equals(SeasonWinter.Season1)).Count());

            var priceinfosApril = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 4);
            Assert.AreEqual(24, priceinfosApril.Count());
            Assert.AreEqual(24, priceinfosApril.Where(f => f.Season.Equals(SeasonSummer.Season1)).Count());
        }

        [TestMethod()]
        public void SeasonPublicHolidayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2021, 01, 02, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            Assert.AreEqual(24,result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 12 && f.PublicHoliday.Equals("no")).Count());
            Assert.AreEqual(0, result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 12 && !f.PublicHoliday.Equals("no")).Count());

            Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 1 && f.PublicHoliday.Equals("yes")).Count());
            Assert.AreEqual(0, result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 1 && !f.PublicHoliday.Equals("yes")).Count());

            Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 2 && f.PublicHoliday.Equals("no")).Count());
            Assert.AreEqual(0, result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Month == 1 && f.StartTime.Day == 2 && !f.PublicHoliday.Equals("no")).Count());

        }

        [TestMethod()]
        public void StartTimeEndTimeTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Count());

            for (int hour = 0; hour < 24; hour++)
            {
                PriceInfo priceInfo =
                result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Date == startDate.Date && f.StartTime.Hour == hour).FirstOrDefault();
                Assert.IsNotNull(priceInfo);
                Assert.AreEqual(0, priceInfo.StartTime.Minute);
                Assert.AreEqual(0, priceInfo.StartTime.Second);
                Assert.AreEqual(0, priceInfo.StartTime.Millisecond);
                if (hour < 23)
                {
                    Assert.AreEqual(priceInfo.StartTime.Date, priceInfo.ExpiredAt.Date);
                    Assert.AreEqual(priceInfo.ExpiredAt.Hour, priceInfo.StartTime.Hour + 1);
                }
                else
                {
                    Assert.AreEqual(priceInfo.StartTime.Date.AddDays(1), priceInfo.ExpiredAt.Date);
                    Assert.AreEqual(priceInfo.ExpiredAt.Hour, 0);
                }
                Assert.AreEqual(0, priceInfo.ExpiredAt.Minute);
                Assert.AreEqual(0, priceInfo.ExpiredAt.Second);
                Assert.AreEqual(0, priceInfo.ExpiredAt.Millisecond);
            };
        }

        [TestMethod()]
        public void AFewHoursTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31, 6, 30, 0);
            DateTime endDate = new DateTime(2020, 12, 31, 7, 30, 0);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.AreEqual(2, result.GridTariff.TariffPrice.PriceInfo.Count());

            for (int hour = 6; hour < 8; hour++)
            {
                PriceInfo priceInfo =
                result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Date == startDate.Date && f.StartTime.Hour == hour).FirstOrDefault();
                Assert.IsNotNull(priceInfo);
                Assert.AreEqual(priceInfo.ExpiredAt.Hour, priceInfo.StartTime.Hour + 1);
            };
        }

        [TestMethod()]
        public void HoursShortNameTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Count());

            foreach (var priceInfo in result.GridTariff.TariffPrice.PriceInfo)
            {
                int hour = priceInfo.StartTime.Hour;
                String hoursShortName = $"{hour.ToString().PadLeft(2, '0')}-{(hour + 1).ToString().PadLeft(2, '0')}";
                Assert.AreEqual(priceInfo.HoursShortName, hoursShortName);
            }
        }

        [TestMethod()]
        public void VariablePriceSaturdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 26);
            DateTime endDate = new DateTime(2020, 12, 26, 23, 59, 59);
            ValidateWeekend(startDate, endDate);
        }

        [TestMethod()]
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

            Variablepriceconfig variablePriceConfig = _tariffContext.Variablepriceconfig.Where(f => f.Tarifftypeid == 1 && f.Monthno == 12).OrderBy(f => f.Pricelevel.Sortorder)
                .FirstOrDefault();
            Assert.IsNotNull(variablePriceConfig);

            for (int hour = 0; hour < 24; hour++)
            {
                PriceInfo priceInfo = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Hour == hour).FirstOrDefault();
                Assert.IsNotNull(priceInfo);
                Assert.AreEqual(variablePriceConfig.Total, priceInfo.VariablePrice.Total);
                Assert.AreEqual(variablePriceConfig.Energy, priceInfo.VariablePrice.Energy);
                Assert.AreEqual(variablePriceConfig.Power, priceInfo.VariablePrice.Power);
                Assert.AreEqual(priceInfo.VariablePrice.Taxes,
                    (variablePriceConfig.Taxenova + variablePriceConfig.Taxenergy + variablePriceConfig.Taxmva));
                Assert.AreEqual(variablePriceConfig.Pricelevel.Pricelevel1, priceInfo.VariablePrice.Level);
                Assert.AreEqual(variablePriceConfig.Uom.Currency, priceInfo.VariablePrice.Currency);
                Assert.AreEqual(variablePriceConfig.Uom.Uom1, priceInfo.VariablePrice.Uom);
            }
        }

        [TestMethod()]
        public void VariablePriceWorkdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);

            List<Variablepriceconfig> variablePriceConfigs = _tariffContext.Variablepriceconfig.Where(f => f.Tarifftypeid == 1 && f.Monthno == 12)
                .ToList();
            Assert.AreEqual(3, variablePriceConfigs.Count());

            foreach (var variablePriceConfig in variablePriceConfigs)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);

                for (int i = 0; i < configHours.Count(); i++)
                {
                    int hour = configHours.ElementAt(i);
                    PriceInfo priceInfo = result.GridTariff.TariffPrice.PriceInfo.Where(f => f.StartTime.Hour == hour).FirstOrDefault();
                    Assert.IsNotNull(priceInfo);
                    Assert.AreEqual(variablePriceConfig.Total, priceInfo.VariablePrice.Total);
                    Assert.AreEqual(variablePriceConfig.Energy, priceInfo.VariablePrice.Energy);
                    Assert.AreEqual(variablePriceConfig.Power, priceInfo.VariablePrice.Power);
                    Assert.AreEqual(priceInfo.VariablePrice.Taxes,
                        (variablePriceConfig.Taxenova + variablePriceConfig.Taxenergy + variablePriceConfig.Taxmva));
                    Assert.AreEqual(variablePriceConfig.Pricelevel.Pricelevel1, priceInfo.VariablePrice.Level);
                    Assert.AreEqual(variablePriceConfig.Uom.Currency, priceInfo.VariablePrice.Currency);
                    Assert.AreEqual(variablePriceConfig.Uom.Uom1, priceInfo.VariablePrice.Uom);
                }
            }
        }

        [TestMethod()]
        public void FixedPriceWorkdayTest()
        {
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = new DateTime(2020, 12, 31, 23, 59, 59);

            int hoursInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month) * 24;
            const int uomID = 4;        //kr/hour

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Count());

            Uom uomKrHour = _tariffContext.Uom.Where(f => f.Id == uomID).FirstOrDefault();
            Assert.IsNotNull(uomKrHour);

            List<Fixedpriceconfig> fixedPriceConfigs = _tariffContext.Fixedpriceconfig.Where(f => f.Tarifftypeid == 1 && f.Monthno == 12).ToList();
            Assert.AreEqual(1, fixedPriceConfigs.Count());

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

                            Assert.AreEqual(priceLevel.Level, fixedPriceConfig.Pricelevel.Pricelevel);
                            Assert.AreEqual(priceLevel.LevelInfo, fixedPriceConfig.Pricelevel.Levelinfo);
                            Assert.AreEqual(priceLevel.Currency, fixedPriceConfig.Uom.Currency);
                            Assert.AreEqual(priceLevel.Uom, uomKrHour.Uom1);
                            Assert.AreEqual(priceLevel.Fixed, fixedVal);
                            Assert.AreEqual(priceLevel.Taxes, taxesVal);
                            Assert.AreEqual(priceLevel.Total, totalVal);
                        }
                    }
                }
            }
        }
        [TestMethod()]
        public void LargeQueryTest()
        {
            const int numDays = 365;
            Setup();
            DateTime startDate = new DateTime(2020, 12, 31);
            DateTime endDate = startDate.AddDays(numDays);

            var result = _TariffQueryService.QueryTariff("private_tou_rush", startDate, endDate);
            bool debug = true;
            //Assert.AreEqual(24, result.GridTariff.TariffPrice.PriceInfo.Count());


            //foreach (var fixedPriceConfig in fixedPriceConfigs)
            //{
            //    foreach (var priceInfo in result.GridTariff.TariffPrice.PriceInfo)
            //    {
            //        foreach (var fixedPrices in priceInfo.FixedPrices)
            //        {
            //            foreach (var priceLevel in fixedPrices.PriceLevel)
            //            {
            //                Decimal fixedVal = Decimal.Round(fixedPriceConfig.Fixed / hoursInMonth, 4);
            //                Decimal taxesVal = Decimal.Round(fixedPriceConfig.Taxes / hoursInMonth, 4);
            //                Decimal totalVal = fixedVal + taxesVal;

            //                Assert.AreEqual(priceLevel.Level, fixedPriceConfig.Pricelevel.Pricelevel);
            //                Assert.AreEqual(priceLevel.LevelInfo, fixedPriceConfig.Pricelevel.Levelinfo);
            //                Assert.AreEqual(priceLevel.Currency, fixedPriceConfig.Uom.Currency);
            //                Assert.AreEqual(priceLevel.Uom, uomKrHour.Uom1);
            //                Assert.AreEqual(priceLevel.Fixed, fixedVal);
            //                Assert.AreEqual(priceLevel.Taxes, taxesVal);
            //                Assert.AreEqual(priceLevel.Total, totalVal);
            //            }
            //        }
            //    }
            //}
        }

    }
}