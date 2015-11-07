using System;
using Domain.Payment.Exceptions;
using Shared;
using Shared.Structs;

namespace Domain.Payment
{
    public class Payment : IEntity<Payment>
    {
        public PaymentId PaymentId { get; set; }
        public Money? Money { get; set; }
        public DateTime? DateTime { get; set; }
        public PaymentType? PaymentType { get; set; }
        public Shop.Shop Shop { get; set; }

        public Payment(PaymentId paymentId, Money? money = null, DateTime? dateTime = null, Shop.Shop shop = null, PaymentType? paymentType = null)
        {
            PaymentId = paymentId;
            Money = money;
            DateTime = dateTime;
            PaymentType = paymentType;
            Shop = shop;
        }

        public Payment(PaymentId paymentId, Money? money, DateTime? dateTime, Shop.Shop shop, string paymentType)
            : this(paymentId, money, dateTime, shop)
        {
            PaymentType pType;

            if (!Enum.TryParse(paymentType, true, out pType))
            {
                throw new WrongPaymentTypeException("Wrong payment type.", "paymentType");
            }

            PaymentType = pType;
        }

        public bool SameIdentityAs(Payment other)
        {
            return PaymentId.Equals(other.PaymentId);
        }
    }
}
