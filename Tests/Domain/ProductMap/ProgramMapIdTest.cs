using System;
using Domain.ProductMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.ProductMap
{
    /// <summary>
    /// Unit tests of ProgramMapId.
    /// </summary>
    [TestClass]
    public class ProgramMapIdTest
    {
        private Guid _id;
        private ProductMapId _productMapId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _id = Guid.NewGuid();
            _productMapId = new ProductMapId(_id);
        }

        [TestMethod]
        public void HasId()
        {
            Assert.AreEqual(
                _id, _productMapId.Id
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(_productMapId.Equals(new ProductMapId(_id)));
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(_productMapId.Equals(new ProductMapId(Guid.NewGuid())));
        }

        [TestMethod]
        public void FromString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(ProductMapId.FromString(_id.ToString()), _productMapId);
        }

        [TestMethod]
        public void ToString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(_productMapId.ToString(), _id.ToString());
        }
    }
}
