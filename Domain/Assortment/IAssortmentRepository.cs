using System.Threading.Tasks;

namespace Domain.Assortment
{
    public interface IAssortmentRepository
    {
        Assortment Get();
        void Save(Product product);
        void Remove(Product product);
    }
}
