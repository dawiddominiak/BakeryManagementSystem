using System;
using Domain.Payment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Domain.Payment
{
    [TestClass]
    public class PaymentTest
    {
        private PaymentId _paymentId;
        private global::Domain.Payment.Payment _payment;

        [TestInitialize]
        public void Initialization()
        {
            _paymentId = new PaymentId(Guid.NewGuid());
            _payment = new global::Domain.Payment.Payment(_paymentId)
            {
                Money = Money.FromNative(15m, "Pln"),
                PaymentType = PaymentType.Direct
            };
        }

        [TestMethod]
        public void HasPaymentId()
        {
            Assert.AreEqual(_payment.PaymentId, _paymentId);
        }

        [TestMethod]
        public void HasMoney()
        {
            Assert.AreEqual(_payment.Money, Money.FromNative(15m, "Pln"));
        }

        [TestMethod]
        public void HasPaymentType()
        {
            Assert.AreEqual(_payment.PaymentType, PaymentType.Direct);
        }

        [TestMethod]
        public void SameIdentityAs_ShouldBeTrue()
        {
            Assert.IsTrue(_payment.SameIdentityAs(
                new global::Domain.Payment.Payment(
                    new PaymentId(
                        Guid.Parse(_paymentId.ToString())
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void SameIdentityAs_ShouldBeFalse()
        {
            Assert.IsFalse(_payment.SameIdentityAs(
                new global::Domain.Payment.Payment(
                    new PaymentId(
                        Guid.NewGuid()
                        )
                    )
                )
            );
        }
    }
}
