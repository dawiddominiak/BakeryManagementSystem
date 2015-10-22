using System.Collections.Generic;

namespace Domain.Assortment
{
    public interface IAssortmentRepository
    {
        Assortment Get();
        void Save(Assortment assortment);
    }
}
