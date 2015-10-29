using Domain.Assortment;

namespace Infrastructure.Persistance.Mapper.Assortment
{
    public class ProductMapper : Mapper<Product, Context.Product.Product>
    {
        public override void MapToDto(Product domainObject, Context.Product.Product dto)
        {
            AutoMapper.Mapper.CreateMap<Product, Context.Product.Product>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id.Id))
                .ForMember(dest => dest.TaxRate, opts => opts.MapFrom(src => src.TaxRate.Rate))
            ;

            AutoMapper.Mapper.Map(domainObject, dto);
        }

        public override void MapToDomainObject(Context.Product.Product dto, Product domainObject)
        {
            AutoMapper.Mapper.CreateMap<Context.Product.Product, Product>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new ProductId(src.Id)))
                .ForMember(dest => dest.TaxRate, opts => opts.MapFrom(src => new TaxRate(src.TaxRate)))
            ;

            AutoMapper.Mapper.Map(dto, domainObject);
        }
    }
}
