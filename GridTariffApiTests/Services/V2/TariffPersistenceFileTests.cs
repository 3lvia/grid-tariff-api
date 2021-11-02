using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridTariffApi.Services.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Services.V2.Tests
{
    [TestClass()]
    public class TariffPersistenceFileTests
    {
        [TestMethod()]
        public void GetTariffPriceStructureTest()
        {
            var test = new TariffPersistenceFile();
            var test2 = test.GetTariffPriceStructure();
        }
    }
}