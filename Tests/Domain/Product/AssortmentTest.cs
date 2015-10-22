using System;
using System.Collections.Generic;
using Domain.Assortment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Product
{
    /// <summary>
    /// Unit tests of Assortment.
    /// </summary>
    [TestClass]
    public class AssortmentTest
    {
        private Assortment _assortment;
        private AssortmentId _assortmentId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _assortmentId = new AssortmentId(Guid.NewGuid());
            _assortment = new Assortment(_assortmentId);
        }

        [TestMethod]
        public void HasAssortmentId()
        {
            Assert.IsTrue(
                _assortmentId.Equals(_assortment.AssortmentId)    
            );
        }

        [TestMethod]
        public void HasAccessToProducts()
        {
            Assert.IsInstanceOfType(
                _assortment.Products,
                typeof(List<global::Domain.Assortment.Product>)
            );
        }

        [TestMethod]
        public void SameIdentityAs_WithDifferentEntity_ShouldBeFalse()
        {
            Assert.IsFalse(
                _assortment.SameIdentityAs(new Assortment(new AssortmentId(Guid.NewGuid())))
            );
        }

        [TestMethod]
        public void SameIdentityAs_WithSameEntity_ShouldBeTrue()
        {
            Assert.IsTrue(
                _assortment.SameIdentityAs(new Assortment(_assortmentId))    
            );
        }
    }
}
