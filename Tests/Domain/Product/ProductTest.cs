using System;
using Domain.Assortment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    [TestClass]
    public class ProductTest
    {
        private global::Domain.Assortment.Product _product;
        private TaxRate _taxRate;

        [TestInitialize]
        public void Initialization()
        {
            _taxRate = new TaxRate(0.23m);
            _product = new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Product 1", _taxRate);
        }

        [TestMethod]
        public void TestHasCode()
        {
            Assert.AreEqual(_product.Code, "P1");
        }

        [TestMethod]
        public void TestHasName()
        {
            Assert.AreEqual(_product.Name, "Product 1");
        }

        [TestMethod]
        public void TestHasTaxRate()
        {
            Assert.IsTrue(_product.TaxRate.Equals(_taxRate));
        }

    }
}
