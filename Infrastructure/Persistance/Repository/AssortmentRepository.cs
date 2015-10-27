using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Domain.Assortment;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Mapper.Assortment;

namespace Infrastructure.Persistance.Repository
{
    public class AssortmentRepository : IAssortmentRepository
    {
        public Assortment Get()
        {
            var mapper = new ProductMapper();
            var products = new List<Product>();
            using (var context = new BakeryContext())
            {
                var dtos = context.Products;
                var domainProducts = new List<Product>();

                foreach (var dto in dtos)
                {
                    domainProducts.Add(
                        mapper.ToDomainObject(dto)
                    );
                }

                products.AddRange(
                    domainProducts
                );
            }

            return new Assortment(products);
        }

        public void Save(Assortment assortment)
        {
            using (var context = new BakeryContext())
            {
                foreach (var product in assortment.Products)
                {
                    var mapper = new ProductMapper();
                    var dto = mapper.ToDto(product);

                    context.Set<Context.Product.Product>().AddOrUpdate(dto);

                }

                context.SaveChanges();
            }
        }
    }
}
