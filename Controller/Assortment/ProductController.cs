using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Assortment;
using Infrastructure.Persistance.Repository;
using System.Windows.Forms;


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

        public void Edit(string code, Product product)
        {
            EnsureAssortment();
            Assortment.Products.RemoveAll(p => p.Code == code);
            Add(product);
        }

        public void Add(Product product)
        {
            EnsureAssortment();
            Assortment.Products.Add(product);
            AssortmentRepository.Save(Assortment);            
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
