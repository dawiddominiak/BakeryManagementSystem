using System.Collections.Generic;
using Domain.Shop;
using Infrastructure.Persistance.Repository;

namespace Controller.Shop
{
    public class OwnerController
    {
        public IOwnerRepository OwnerRepository { get; set; } = new OwnerRepository();
        
        public void Save(Owner owner)
        {
            OwnerRepository.Save(owner);
        }

        public void Remove(Owner owner)
        {
            OwnerRepository.Remove(owner);
        }

        public List<Owner> GetAll()
        {
            return OwnerRepository.GetAll();
        }

        public Owner Get(OwnerId ownerId)
        {
            return OwnerRepository.Get(ownerId);
        }

        public Owner GetByCode(string code)
        {
            return OwnerRepository.GetByCode(code);
        }

        public OwnerId NextOwnerId()
        {
            return OwnerRepository.NextOwnerId();
        }
    }
}
