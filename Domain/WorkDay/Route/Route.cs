using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkDay.Route
{
    class Route
    {
        public IssuedGoods IssuedGoods { get; set; }
        public ReturnedGoods ReturnedGoods { get; set; }
        public ReturnedReturns ReturnedReturns { get; set; }
        public WarehouseIssue WarehouseIssue { get; set; }
        public List<Payment.Payment> PaymentList { get; private set; }
    }
}
