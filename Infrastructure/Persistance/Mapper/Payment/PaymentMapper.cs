//using Domain.Payment;
//using Shared.Structs;
//
//namespace Infrastructure.Persistance.Mapper.Payment
//{
//    //TODO: automapper
//    public class PaymentMapper : IMapper<Domain.Payment.Payment, Context.Payment.Payment>
//    {
//        public Context.Payment.Payment ToDto(Domain.Payment.Payment domainObject)
//        {
//            var dto = new Context.Payment.Payment
//            {
//                PaymentId = domainObject.PaymentId.Id,
//                PaymentType = domainObject.PaymentType.ToString()
//            };
//
//            if (domainObject.DateTime != null)
//            {
//                dto.DateTime = domainObject.DateTime.Value;                
//            }
//
//            if (domainObject.Money != null)
//            {
//                dto.Amount = domainObject.Money.Value.Amount;
//                dto.Currency = domainObject.Money.Value.Currency.ToString().ToLower();
//            }
//
//            dto.Shop = domainObject.Shop;
//
//            return dto;
//        }
//
//        public Domain.Payment.Payment ToDomainObject(Context.Payment.Payment dto)
//        {
//            return new Domain.Payment.Payment(
//                new PaymentId(dto.PaymentId),
//                new Money(dto.Amount, dto.Currency),
//                dto.DateTime,
//                dto.PaymentType
//            );
//        }
//    }
//}
