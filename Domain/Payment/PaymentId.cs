using System;
using Shared;

namespace Domain.Payment
{
    public class PaymentId : GuidId
    {
        public PaymentId(Guid id)
            : base(id)
        { }

        public PaymentId(string id)
            : base(id)
        { }
    }
}
