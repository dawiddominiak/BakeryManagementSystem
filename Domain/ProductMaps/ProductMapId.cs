using System;
namespace Domain.ProductMaps
{
    public struct ProductMapId : IEquatable<ProductMapId>
    {
        public Guid Id { get; private set; }

        public ProductMapId(Guid id)
            : this()
        {
            Id = id;
        }

        public static ProductMapId FromString(string id)
        {
            return new ProductMapId(new Guid(id));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(ProductMapId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
