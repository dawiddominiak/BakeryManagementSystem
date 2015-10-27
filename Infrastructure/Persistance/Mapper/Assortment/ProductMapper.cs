using Domain.Assortment;

namespace Infrastructure.Persistance.Mapper.Assortment
{
    public class ProductMapper : IMapper<Product, Context.Product.Product>
    {
        public Context.Product.Product ToDto(Product domainObject)
        {
            AutoMapper.Mapper.CreateMap<Product, Context.Product.Product>()
                .ForMember(dest => dest.TaxRate, opts => opts.MapFrom(src => src.TaxRate.Rate))
            ;

            var dto = AutoMapper.Mapper.Map<Context.Product.Product>(domainObject);

            return dto;
        }

        public Product ToDomainObject(Context.Product.Product dto)
        {
            AutoMapper.Mapper.CreateMap<Context.Product.Product, Product>()
                .ForMember(dest => dest.TaxRate, opts => opts.MapFrom(src => new TaxRate(src.TaxRate)))
            ;

            var domain = AutoMapper.Mapper.Map<Product>(dto);

            return domain;
        }
    }
}
