using System.Collections.Generic;
using Shared;

namespace Domain.Assortment
{
    public class Assortment : IEntity<Assortment>, IAggregateRoot
    {
        public AssortmentId AssortmentId { get; private set; }
        public List<Product> Products { get; private set; }

        public Assortment(AssortmentId id)
        {
            AssortmentId = id;

            Products = new List<Product>();
        }

        public bool SameIdentityAs(Assortment other)
        {
            return AssortmentId.Equals(other.AssortmentId);
        }
    }
}
