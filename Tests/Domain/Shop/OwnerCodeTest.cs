using System;
using Domain.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop
{
    [TestClass]
    public class OwnerCodeTest
    {
        private OwnerCode _ownerCode;

        [TestInitialize]
        public void Initialization()
        {
            _ownerCode = new OwnerCode("AL");
        }

        [TestMethod]
        public void HasCode()
        {
            Assert.AreEqual(_ownerCode.Code, "AL");
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(
                _ownerCode.Equals(new OwnerCode("AK"))    
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(
                _ownerCode.Equals(new OwnerCode("AL"))
            );
        }
    }
}
