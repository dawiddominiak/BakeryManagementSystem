using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkDay.Shop
{
    public class Shop
    {
        public Order Order { get; set; }
        public Delivery Delivery { get; set; }
        public Returns Returns { get; set; }
        public Domain.Payment.Payment Payment { get; set; }
        public PriceList.PriceList PriceList { get; set; }
    }
}
