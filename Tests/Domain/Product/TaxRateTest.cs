using Domain.Assortment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    [TestClass]
    public class TaxRateTest
    {
        private TaxRate _taxRate;

        [TestInitialize]
        public void Initialization()
        {
            _taxRate = new TaxRate(0.23m);
        }

        [TestMethod]
        public void TestHasRate()
        {
            Assert.AreEqual(_taxRate.Rate, 0.23m);
        }

        [TestMethod]
        public void TestEquals_ShouldBeTrue()
        {
            Assert.IsTrue(_taxRate.Equals(new TaxRate(0.23m)));
        }

        [TestMethod]
        public void TestEquals_ShouldBeFalse()
        {
            Assert.IsFalse(_taxRate.Equals(new TaxRate(0.22m)));
        }
    }
}
