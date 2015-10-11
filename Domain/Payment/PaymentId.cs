using System;
using Shared;

namespace Domain.Payment
{
    public class PaymentId : IValueObject<PaymentId>
    {
        public Guid Id { get; private set; }

        public PaymentId(Guid id)
        {
            Id = id;
        }

        public static PaymentId FromString(string id)
        {
            return new PaymentId(new Guid(id));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool SameValueAs(PaymentId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
