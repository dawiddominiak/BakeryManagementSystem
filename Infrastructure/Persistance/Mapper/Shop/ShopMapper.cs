//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Infrastructure.Persistance.Mapper.Payment;
//
//namespace Infrastructure.Persistance.Mapper.Shop
//{
//    //TODO: automapper
//    public class ShopMapper : IMapper<Domain.Shop.Shop, Context.Shop.Shop>
//    {
//        public Context.Shop.Shop ToDto(Domain.Shop.Shop domainObject)
//        {
//            var payments = new Collection<Context.Payment.Payment>();
//
//            foreach (var payment in domainObject.Payments)
//            {
//                payments.Add(new PaymentMapper().ToDto(payment.Value));
//            }
//
//            return new Context.Shop.Shop
//            {
//                Code = domainObject.Code.Code,
//                Name = domainObject.Name,
//                Owner = (new OwnerMapper()).ToDto(domainObject.Owner),
//                Payments = payments,
//
//            };
//        }
//
//        public Domain.Shop.Shop ToDomainObject(Context.Shop.Shop dto)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
