using System;

namespace Domain.Payment
{
    public struct PaymentId : IEquatable<PaymentId>
    {
        public Guid Id { get; private set; }

        public PaymentId(Guid id) : this()
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

        public bool Equals(PaymentId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
