using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarketRegister;

namespace UnitTestSuperMarketRegister
{
    [TestClass]
    public class SuperMarketRegister
    {
        
        [TestMethod]
        public void TestPurchase()
        {
            var receipt = new Receipt();
            receipt.AddItem(1, "Candy Bar", 0.50);
            receipt.AddItem(2, "Soda", 1);
            var expected =
                @"1 Candy Bar @ $0.50 = $0.50
2 Soda @ $1.00 = $2.00
SubTotal = $2.50
Tax (10%) = $0.25
Total = $2.75";
            Assert.AreEqual(expected, receipt.ToString());
        }


    }
}
