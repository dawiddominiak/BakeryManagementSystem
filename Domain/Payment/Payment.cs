using Shared;

namespace Domain.Payment
{
    public class Payment : IEntity<Payment>, IAggregateRoot
    {
        public PaymentId PaymentId { get; private set; }
        public Shared.Structs.Money Money { get; set; }
        public PaymentType PaymentType { get; set; }

        public Payment(PaymentId paymentId)
        {
            PaymentId = paymentId;
        }

        public bool SameIdentityAs(Payment other)
        {
            return PaymentId.Equals(other.PaymentId);
        }
    }
}
