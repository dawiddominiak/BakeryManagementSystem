using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment
{
    public class PaymentEntity
    {
        public Shared.Structs.Money Money { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
