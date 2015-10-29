using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Domain.Assortment;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Mapper.Assortment;

namespace Infrastructure.Persistance.Repository
{
    public class AssortmentRepository : IAssortmentRepository
    {
        public ProductMapper Mapper { get; set; }

        public AssortmentRepository()
        {
            Mapper = new ProductMapper();
        }

        public List<Product> GetAll()
        {
            using (var context = new BakeryContext())
            {
                var products = context
                    .Products;

                var list = new List<Product>();
                
                foreach (var product in products)
                {
                    list.Add(Mapper.ToDomainObject(product));
                }

                return list;
            }
        }

        public Product Get(ProductId productId)
        {
            using (var context = new BakeryContext())
            {
                var dto = context
                    .Products
                    .Find(productId.ToString());

                return dto == null ? null : Mapper.ToDomainObject(dto);
            }
        }

        public void Save(Product product)
        {
            using (var context = new BakeryContext())
            {
                var dto = context.Products.Find(product.Id.Id) ?? new Context.Product.Product();
                
                Mapper.MapToDto(product, dto);

                context.Set<Context.Product.Product>().AddOrUpdate(dto);
                context.SaveChanges();
            }
        }

        public void Remove(Product product)
        {
            using (var context = new BakeryContext())
            {
                context.Products.Remove(
                    context.Products.Find(product.Id.Id)
                );

                context.SaveChanges();
            }
        }

        public ProductId NextProductId()
        {
            return new ProductId(Guid.NewGuid());
        }
    }
}
