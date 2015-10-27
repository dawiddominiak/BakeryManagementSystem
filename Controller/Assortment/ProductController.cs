using System.Threading.Tasks;
using Domain.Assortment;
using Infrastructure.Persistance.Repository;


namespace Controller.Assortment
{
    public class ProductController
    {
        public IAssortmentRepository AssortmentRepository { get; set; }
        public Domain.Assortment.Assortment Assortment { get; set; }

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

        public void EnsureAssortment()
        {
            if (Assortment == null)
            {
                Get();
            }
        }

        public Domain.Assortment.Assortment Get()
        {
            var assortment = AssortmentRepository.Get();
            Assortment = assortment;
            return assortment;
        }
    }
}
