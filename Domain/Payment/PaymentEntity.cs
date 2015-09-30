using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment
{
    class PaymentEntity
    {
        public Shared.Money Money { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
