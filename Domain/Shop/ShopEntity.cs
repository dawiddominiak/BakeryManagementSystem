using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shop
{
    public class ShopEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public OwnerEntity Owner { get; set; }
        public ProductMaps.ProductMapEntity Order { get; set; }
        public ProductMaps.ProductMapEntity Delivery { get; set; }
        public ProductMaps.ProductMapEntity Returns { get; set; }
        public List<Payment.PaymentEntity> Payments { get; set; }
        public Shared.Structs.Address Address { get; set; }
        public List<Shared.Structs.Phone> Phones { get; private set; }
    }
}
