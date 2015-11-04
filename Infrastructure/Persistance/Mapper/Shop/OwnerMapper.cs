using System;
using Domain.Shop;
using Infrastructure.Persistance.Context.Shop;
using Shared.Structs;
using Owner = Domain.Shop.Owner;

namespace Infrastructure.Persistance.Mapper.Shop
{
    public class OwnerMapper : Mapper<Owner, Context.Shop.Owner>
    {
        public override void MapToDto(Owner domainObject, Context.Shop.Owner dto)
        {
            AutoMapper.Mapper.CreateMap<Owner, Context.Shop.Owner>()
                .ForMember(dest => dest.OwnerAddress, opts => opts.MapFrom(src => src.Address))
                .ForMember(dest => dest.Shops, opts => opts.Ignore())
            ;

            AutoMapper.Mapper.CreateMap<OwnerId, Guid>()
                .ConvertUsing(id => id.Id)
            ;

            AutoMapper.Mapper.CreateMap<Address, OwnerAddress>();

            AutoMapper.Mapper.CreateMap<Phone, OwnerPhone>()
                .ConvertUsing(phone => new OwnerPhone
                {
                    Country = phone.CountryCode,
                    Area = phone.RegionalCode,
                    Number = phone.Number
                })
            ;

            AutoMapper.Mapper.Map(domainObject, dto);
        }

        public override void MapToDomainObject(Context.Shop.Owner dto, Owner domainObject)
        {
            AutoMapper.Mapper.CreateMap<Context.Shop.Owner, Owner>()
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.OwnerAddress))
                .ForMember(dest => dest.Shops, opts => opts.Ignore())
            ;

            AutoMapper.Mapper.CreateMap<Guid, OwnerId>()
                .ConvertUsing(guid => new OwnerId(guid))
            ;

            AutoMapper.Mapper.CreateMap<OwnerAddress, Address>()
                .ConvertUsing(
                    ownerAddress => new Address(
                        ownerAddress.Street, 
                        ownerAddress.PostalCode, 
                        ownerAddress.City, 
                        ownerAddress.Country
                    )
                )
            ;

            AutoMapper.Mapper.CreateMap<OwnerPhone, Phone>()
                .ConvertUsing(
                    ownerPhone => new Phone(
                        ownerPhone.Country, 
                        ownerPhone.Area,
                        ownerPhone.Number
                    )
                )
            ;

            AutoMapper.Mapper.Map(dto, domainObject);
        }
    }
}
