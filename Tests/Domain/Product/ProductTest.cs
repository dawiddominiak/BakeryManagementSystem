using Domain.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    [TestClass]
    public class ProductTest
    {
        private global::Domain.Product.Product _product;

        [TestInitialize]
        public void Initialization()
        {
            _product = new global::Domain.Product.Product(new ProductCode("P1"))
            {
                Name = "Test name",
                TaxRate = new TaxRate(0.23m)
            };
        }

        [TestMethod]
        public void TestHasCode()
        {
            Assert.IsTrue(_product.Code.Equals(new ProductCode("P1")));
        }

        [TestMethod]
        public void TestHasName()
        {
            Assert.AreEqual(_product.Name, "Test name");
        }

        [TestMethod]
        public void TestHasTaxRate()
        {
            Assert.IsTrue(_product.TaxRate.Equals(new TaxRate(0.23m)));
        }

        [TestMethod]
        public void TestSameIdentityAs_ShouldBeTrue()
        {
            Assert.IsTrue(_product.SameIdentityAs(
                new global::Domain.Product.Product(new ProductCode("P1")))
            );
        }

        [TestMethod]
        public void TestSameIdentityAs_ShouldBeFalse()
        {
            Assert.IsFalse(_product.SameIdentityAs(
                new global::Domain.Product.Product(new ProductCode("P2")))
            );
        }
    }
}
