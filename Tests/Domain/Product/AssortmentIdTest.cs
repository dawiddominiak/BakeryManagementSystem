using System;
using Domain.Assortment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    /// <summary>
    /// Unit tests of AssortmentId.
    /// </summary>
    [TestClass]
    public class AssortmentIdTest
    {
        private Guid _id;
        private AssortmentId _assortmentId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _id = Guid.NewGuid();
            _assortmentId = new AssortmentId(_id);
        }

        [TestMethod]
        public void HasId()
        {
            Assert.AreEqual(
                _id, _assortmentId.Id
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(_assortmentId.Equals(new AssortmentId(_id)));
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(_assortmentId.Equals(new AssortmentId(Guid.NewGuid())));
        }

        [TestMethod]
        public void FromString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(AssortmentId.FromString(_id.ToString()), _assortmentId);
        }

        [TestMethod]
        public void ToString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(_assortmentId.ToString(), _id.ToString());
        }
    }
}
