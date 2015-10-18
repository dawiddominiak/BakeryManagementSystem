using Domain.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    [TestClass]
    public class ProductCodeTest
    {
        private ProductCode _productCode;

        [TestInitialize]
        public void Initialization()
        {
            _productCode = new ProductCode("AB");
        }

        [TestMethod]
        public void TestHasCode()
        {
            Assert.AreEqual(_productCode.Code, "AB");
        }

        [TestMethod]
        public void TestEquals_ShouldBeTrue()
        {
            Assert.IsTrue(_productCode.Equals(new ProductCode("AB")));
        }

        [TestMethod]
        public void TestEquals_ShouldBeFalse()
        {
            Assert.IsFalse(_productCode.Equals(new ProductCode("AC")));
        }
    }
}
