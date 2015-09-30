using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shop
{
    class ShopEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public OwnerEntity Owner { get; set; }
        public ProductMaps.ShopOrderProductMap Order { get; set; }
        public ProductMaps.ShopDeliveryProductMap Delivery { get; set; }
        public ProductMaps.ShopReturnsProductMap Returns { get; set; }
        public List<Payment.PaymentEntity> Payments { get; set; }
        public Shared.Address Address { get; set; }
        public List<Shared.Phone> Phones { get; private set; }
    }
}
