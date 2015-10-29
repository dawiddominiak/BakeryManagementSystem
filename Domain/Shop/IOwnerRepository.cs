using System.Collections.Generic;

namespace Domain.Shop
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
        Owner Get(OwnerId ownerId);
        Owner GetByCode(OwnerId code);
        void Save(Owner owner);
        void Remove(Owner owner);
        OwnerId NextOwnerId();
    }
}
