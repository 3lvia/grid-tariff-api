using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models.TariffQuery;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Kunde.TariffApiTests
{
    public class TestHelper
    {
        public TestHelper()
        {
            
        }

        public Company GetCompanyElvia ()
        {
            return new Company()
            {
                Id = 1,
                CompanyName = "Elvia AS"
            };
        }

        public Company GetCompanyFoobar()
        {
            return new Company()
            {
                Id = 2,
                CompanyName = "Foobar Inc"
            };
        }

        public Tarifftype GetTariffRush()
        {
            return new Tarifftype()
            {
                Tariffkey = "private_tou_rush",
                Companyid = 1,
                Customertype = "private",
                Title = "Nettleie Rush & Ro",
                Resolution = 60,
                Description = "Tariff focused on lowering energy consumption during high consumption periods of the day"
            };
        }

        public Tarifftype GetTariffDayNight()
        {
            return new Tarifftype()
            {
                Tariffkey = "private_tou_daynight",
                Companyid = 1,
                Customertype = "private",
                Title = "Nettleie Dag&Natt",
                Resolution = 60,
                Description = "Tariff focused on moving energy consumption from day to night"
            };
        }


        public bool Contains(List<TariffApi.Models.TariffType> model, Tarifftype db)
        {
            foreach (var tariffType in model)
            {
                if (
                    tariffType.Company.Equals(db.Company.CompanyName)
                    && tariffType.CustomerType.Equals(db.Customertype)
                    && tariffType.Title.Equals(db.Title)
                    && tariffType.Resolution.Equals(db.Resolution)
                    && tariffType.Description.Equals(db.Description))
                {
                    return true;
                }
            }
            return false;
        }

        public List<UnitofMeasure> GetUoms()
        {
            List<UnitofMeasure> retVal = new List<UnitofMeasure>();
            List<String> strElements = new List<string>()
            {
                "1;NOK;kr/month",
                "2;NOK;kr/kWh",
                "3;NOK;øre/kWh",
                "4;NOK;kr/hour"
            };
            foreach (var strElement in strElements)
            {
                string[] elements = strElement.Split(";");
                retVal.Add(new UnitofMeasure() { 
                    Id = Convert.ToInt32(elements[0]),
                    Currency = elements[1],
                    Unit = elements[2]

                });
            }
            return retVal;
        }

        public List<Season> GetSeasons()
        {
            List<Season> retVal = new List<Season>();
            List<String> strElements = new List<string>()
            {
                "1;summerLow",
                "2;summer",
                "3;summerHigh",
                "4;winterLow",
                "5;winter",
                "6;winterHigh"
            };

            foreach (var strElement in strElements)
            {
                int ctr = 0;
                string[] elements = strElement.Split(";");
                retVal.Add(new Season()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Season1 = elements[ctr++]
                });
            }
            return retVal;
        }

        public List<Publicholiday> GetPublicHolidays()
        {
            List<Publicholiday> retval = new List<Publicholiday>();
            List<String> strElements = new List<string>()
            {
                "1;2021-01-01;Første nyttårsdag"
            };

            foreach (var strElement in strElements)
            {
                int ctr = 0;
                string[] elements = strElement.Split(";");
                retval.Add(new Publicholiday()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Holidaydate = DateTime.Parse(elements[ctr++]),
                    Description = elements[ctr++]
                });
            }
            return retval;
        }

        public List<Pricelevel> GetPricelevels()
        {
            List<Pricelevel> retval = new List<Pricelevel>();
            List<String> strElements = new List<string>()
            {
                "1;0;VERY_CHEAP",
                "2;1;CHEAP",
                "3;2;NORMAL",
                "4;3;EXPENSIVE",
                "5;4;VERY_EXPENSIVE"
            };

            foreach (var strElement in strElements)
            {
                int ctr = 0;
                string[] elements = strElement.Split(";");
                retval.Add(new Pricelevel()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Sortorder = Convert.ToInt32(elements[ctr++]),
                    PricelevelDescription = elements[2]
                });;
            }
            return retval;
        }

        public List<Fixedpricelevel> GetFixedPricelevels()
        {
            List<Fixedpricelevel> retval = new List<Fixedpricelevel>();
            List<String> strElements = new List<string>()
            {
                "1;Level1;For alle privatkunder i Elvia med tariff: Nettleie Elvia sør",
                "2;Level2;For alle privatkunder i Elvia med tariff: Nettleie Rush&Ro eller Nettleie Dag&Natt"
            };

            foreach (var strElement in strElements)
            {
                int ctr = 0;
                string[] elements = strElement.Split(";");
                retval.Add(new Fixedpricelevel()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Pricelevel = elements[ctr++],
                    Levelinfo = elements[ctr++]
                }); ;
            }
            return retval;
        }

        public List<Fixedpriceconfig> GetFixedPriceConfigs()
        {
            List<Fixedpriceconfig> retval = new List<Fixedpriceconfig>();
            List<String> strElements = new List<string>()
            {
                "1;1;5;1;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "2;1;5;2;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "3;1;5;3;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "4;1;2;4;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "5;1;2;5;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "6;1;2;6;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "7;1;2;7;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "8;1;2;8;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "9;1;2;9;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "10;1;2;10;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "11;1;5;11;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "12;1;5;12;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "13;2;5;1;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "14;2;5;2;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "15;2;5;3;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "16;2;2;4;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "17;2;2;5;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "18;2;2;6;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "19;2;2;7;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "20;2;2;8;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "21;2;2;9;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "22;2;2;10;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "23;2;5;11;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31",
                "24;2;5;12;2;200.0000;160.0000;40.0000;1;2020-11-01;2024-12-31"
            };

            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            foreach (var strElement in strElements)
            {
                string[] elements = strElement.Split(";");
                int ctr = 0;
                retval.Add(new Fixedpriceconfig()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Tarifftypeid = Convert.ToInt32(elements[ctr++]),
                    Seasonid = Convert.ToInt32(elements[ctr++]),
                    Monthno = Convert.ToInt32(elements[ctr++]),
                    Pricelevelid = Convert.ToInt32(elements[ctr++]),
                    Total = Decimal.Parse(elements[ctr++], numberFormatInfo),
                    Fixed = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Taxes = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Uomid = Convert.ToInt32(elements[ctr++], numberFormatInfo),
                    Pricefromdate = DateTime.Parse(elements[ctr++]),
                    Pricetodate = DateTime.Parse(elements[ctr++])
                }); ;
            }
            return retval;
        }

        public List<Variablepriceconfig> GetVariablePriceConfigs()
        {
            List<Variablepriceconfig> retval = new List<Variablepriceconfig>();
            List<String> strElements = new List<string>()
            {
                "1,1,5,1,4,0.8470,0.5406,0.0000,0.1352,0.0100,0.1613,2,2020-11-01,2024-12-31,8;9;10;11;16;17;18;19",
                "2,1,5,1,3,0.5805,0.3274,0.0000,0.0818,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;12;13;14;15;20;21",
                "3,1,5,1,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "4,1,5,2,4,0.8470,0.5406,0.0000,0.1352,0.0100,0.1613,2,2020-11-01,2024-12-31,8;9;10;11;16;17;18;19",
                "5,1,5,2,3,0.5805,0.3274,0.0000,0.0818,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;12;13;14;15;20;21",
                "6,1,5,2,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "7,1,5,3,4,0.8470,0.5406,0.0000,0.1352,0.0100,0.1613,2,2020-11-01,2024-12-31,8;9;10;11;16;17;18;19",
                "8,1,5,3,3,0.5805,0.3274,0.0000,0.0818,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;12;13;14;15;20;21",
                "9,1,5,3,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "10,1,2,4,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "11,1,2,4,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "12,1,2,5,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "13,1,2,5,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "14,1,2,6,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "15,1,2,6,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "16,1,2,7,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "17,1,2,7,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "18,1,2,8,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "19,1,2,8,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "20,1,2,9,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "21,1,2,9,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "22,1,2,10,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "23,1,2,10,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "24,1,5,11,4,0.8470,0.5406,0.0000,0.1352,0.0100,0.1613,2,2020-11-01,2024-12-31,8;9;10;11;16;17;18;19",
                "25,1,5,11,3,0.5805,0.3274,0.0000,0.0818,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;12;13;14;15;20;21",
                "26,1,5,11,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "27,1,5,12,4,0.8470,0.5406,0.0000,0.1352,0.0100,0.1613,2,2020-11-01,2024-12-31,8;9;10;11;16;17;18;19",
                "28,1,5,12,3,0.5805,0.3274,0.0000,0.0818,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;12;13;14;15;20;21",
                "29,1,5,12,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "30,2,5,1,4,0.7170,0.4366,0.0000,0.1091,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "31,2,5,1,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "32,2,5,2,4,0.7170,0.4366,0.0000,0.1091,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "33,2,5,2,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "34,2,5,3,4,0.7170,0.4366,0.0000,0.1091,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "35,2,5,3,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "36,2,2,4,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "37,2,2,4,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "38,2,2,5,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "39,2,2,5,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "40,2,2,6,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "41,2,2,6,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "42,2,2,7,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "43,2,2,7,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "44,2,2,8,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "45,2,2,8,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "46,2,2,9,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "47,2,2,9,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "48,2,2,10,3,0.2765,0.0842,0.0000,0.0210,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "49,2,2,10,2,0.2515,0.0642,0.0000,0.0160,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "50,2,5,11,4,0.7170,0.4366,0.0000,0.1091,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "51,2,5,11,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23",
                "52,2,5,12,4,0.7170,0.4366,0.0000,0.1091,0.0100,0.1613,2,2020-11-01,2024-12-31,6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21",
                "53,2,5,12,2,0.2890,0.0942,0.0000,0.0235,0.0100,0.1613,2,2020-11-01,2024-12-31,0;1;2;3;4;5;22;23"
            };

            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            foreach (var strElement in strElements)
            {
                string[] elements = strElement.Split(",");
                int ctr = 0;
                retval.Add(new Variablepriceconfig()
                {
                    Id = Convert.ToInt32(elements[ctr++]),
                    Tarifftypeid = Convert.ToInt32(elements[ctr++]),
                    Seasonid = Convert.ToInt32(elements[ctr++]),
                    Monthno = Convert.ToInt32(elements[ctr++]),
                    Pricelevelid = Convert.ToInt32(elements[ctr++]),
                    Total = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Energy = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Power = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Taxmva = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Taxenova = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Taxenergy = Convert.ToDecimal(elements[ctr++], numberFormatInfo),
                    Uomid = Convert.ToInt32(elements[ctr++]),
                    Pricefromdate = Convert.ToDateTime(elements[ctr++]),
                    Pricetodate = Convert.ToDateTime(elements[ctr++]),
                    Hours = elements[ctr++]
                });
            }
            return retval;
        }
    }
}
