using System;
using Domain.PriceLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.PriceList
{
    /// <summary>
    /// Unit tests of PriceListId
    /// </summary>
    [TestClass]
    public class PriceListIdTest
    {
        private Guid _id;
        private PriceListId _priceListId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _id = Guid.NewGuid();
            _priceListId = new PriceListId(_id);
        }

        [TestMethod]
        public void HasId()
        {
            Assert.AreEqual(
                _id, _priceListId.Id
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(_priceListId.Equals(new PriceListId(_id)));
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(_priceListId.Equals(new PriceListId(Guid.NewGuid())));
        }

        [TestMethod]
        public void FromString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(PriceListId.FromString(_id.ToString()), _priceListId);
        }

        [TestMethod]
        public void ToString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(_priceListId.ToString(), _id.ToString());
        }
    }
}
