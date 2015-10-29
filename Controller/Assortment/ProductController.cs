using System.Collections.Generic;
using Domain.Assortment;
using Infrastructure.Persistance.Repository;


namespace Controller.Assortment
{
    public class ProductController
    {
        public IAssortmentRepository AssortmentRepository { get; set; }

        public ProductController()
        {
            AssortmentRepository = new AssortmentRepository();
        }

        public void Save(Product product)
        {
            AssortmentRepository.Save(product);            
        }

        public void Remove(Product product)
        {
            AssortmentRepository.Remove(product);
        }

        public List<Product> GetAll()
        {
            return AssortmentRepository.GetAll();
        }

        public Product Get(ProductId productId)
        {
            return AssortmentRepository.Get(productId);
        }

        public ProductId NextProductId()
        {
            return AssortmentRepository.NextProductId();
        }
    }
}
