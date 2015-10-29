using Domain.Shop;

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

            AutoMapper.Mapper.Map(domainObject, dto);
        }

        public override void MapToDomainObject(Context.Shop.Owner dto, Owner domainObject)
        {
            AutoMapper.Mapper.CreateMap<Context.Shop.Owner, Owner>()
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.OwnerAddress))
                .ForMember(dest => dest.Shops, opts => opts.Ignore())
            ;

            AutoMapper.Mapper.Map(dto, domainObject);
        }
    }
}
