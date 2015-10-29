using System;
using Domain.Payment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Payment
{
    [TestClass]
    public class PaymentIdTest
    {
        private Guid _id;
        private PaymentId _paymentId;

        [TestInitialize]
        public void Initialization()
        {
            _id = Guid.NewGuid();
            _paymentId = new PaymentId(_id);
        }

        [TestMethod]
        public void HasId()
        {
            Assert.AreEqual(_paymentId.Id, _id);
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(_paymentId.Equals(new PaymentId(_id)));
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(_paymentId.Equals(new PaymentId(Guid.NewGuid())));
        }

        [TestMethod]
        public void FromString_ShouldReturnsCorrectString()
        {
            Assert.IsTrue(new PaymentId(_id.ToString()).Equals(_paymentId));
        }

        [TestMethod]
        public void ToString_ShouldReturnsCorrectString()
        {
            Assert.AreEqual(_paymentId.ToString(), _id.ToString());
        }
    }
}
