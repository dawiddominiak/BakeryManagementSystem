using System.Collections.Generic;

namespace Domain.Assortment
{
    public interface IAssortmentRepository
    {
        List<Product> GetAll();
        Product Get(ProductId productId);
        void Save(Product product);
        void Remove(Product product);
        ProductId NextProductId();
    }
}
