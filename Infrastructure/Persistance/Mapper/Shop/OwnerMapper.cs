using System.Collections.ObjectModel;
using System.Linq;
using Domain.Shop;
using Infrastructure.Persistance.Context.Shop;
using Shared.Structs;
using Owner = Domain.Shop.Owner;

namespace Infrastructure.Persistance.Mapper.Shop
{
    //TODO: automapper
    public class OwnerMapper : IMapper<Owner, Context.Shop.Owner>
    {
        public Context.Shop.Owner ToDto(Owner domainObject)
        {
            var phones = new Collection<OwnerPhone>();
            foreach (var phone in domainObject.Phones)
            {
                phones.Add(new OwnerPhone
                {
                    Country = phone.CountryCode,
                    Area = phone.RegionalCode,
                    Number = phone.Number
                });
            }

            return new Context.Shop.Owner
            {
                Code = domainObject.Code.Code,
                Name = domainObject.Name,
                NationalEconomyRegister = domainObject.NationalEconomyRegister,
                TaxIdentificationNumber = domainObject.TaxIdentificationNumber,
                OwnerAddress = new OwnerAddress
                {
                    City = domainObject.Address.City,
                    Country = domainObject.Address.Country,
                    PostalCode = domainObject.Address.PostalCode,
                    Street = domainObject.Address.Street
                },
                Phones = phones
            };
        }

        public Owner ToDomainObject(Context.Shop.Owner dto)
        {
            return new Owner(new OwnerCode(dto.Code))
            {
                Name = dto.Name,
                NationalEconomyRegister = dto.NationalEconomyRegister,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                Address = new Address(
                    dto.OwnerAddress.Street, 
                    dto.OwnerAddress.PostalCode,
                    dto.OwnerAddress.City,
                    dto.OwnerAddress.Country
                ),
                Phones = dto.Phones.Select(phone => new Phone(phone.Country, phone.Area, phone.Number)).ToList()
            };
        }
    }
}
