using System;
using Domain.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop
{
    [TestClass]
    public class ShopCodeTest
    {
        private ShopCode _shopCode;

        [TestInitialize]
        public void Initialization()
        {
            _shopCode = new ShopCode("SC");
        }

        [TestMethod]
        public void HasCode()
        {
            Assert.AreEqual(_shopCode.Code, "SC");
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(
                _shopCode.Equals(new ShopCode("SA"))
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(
                _shopCode.Equals(new ShopCode("SC"))
            );
        }
    }
}
