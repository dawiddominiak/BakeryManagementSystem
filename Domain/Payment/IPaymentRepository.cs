using System.Collections.Generic;

namespace Domain.Payment
{
    public interface IPaymentRepository
    {
        Payment Get(PaymentId id);
        List<Payment> GetAll();
        void Save(Payment payment);
        PaymentId GetNextId();
    }
}
