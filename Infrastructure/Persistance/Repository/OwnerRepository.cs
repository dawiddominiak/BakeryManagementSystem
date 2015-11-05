using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Domain.Shop;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Mapper.Shop;

namespace Infrastructure.Persistance.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerMapper Mapper { get; set; }

        public OwnerRepository()
        {
            Mapper = new OwnerMapper();
        }

        public List<Owner> GetAll()
        {
            using (var context = new BakeryContext())
            {
                var owners = context.Owners;
                var list = new List<Owner>();
                
                foreach (
                    var owner 
                        in 
                    owners
                        .Include("OwnerAddress")
                        .Include("Phones")
                    )
                {
                    list.Add(Mapper.ToDomainObject(owner));
                }

                return list;
            }
        }

        public Owner Get(OwnerId ownerId)
        {
            using (var context = new BakeryContext())
            {
                var dto = context
                    .Owners
                    .Find(ownerId.Id);

                return dto == null ? null : Mapper.ToDomainObject(dto);
            }
        }

        public Owner GetByCode(string code)
        {
            using (var context = new BakeryContext())
            {
                var dtos = context
                    .Owners
                    .Where(el => el.Code == code);

                if (dtos.Any())
                {
                    return null;
                }

                var dto = dtos.First();

                return Mapper.ToDomainObject(dto);
            }
        }

        public void Save(Owner owner)
        {
            using (var context = new BakeryContext())
            {
                var manager = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager;
                var dto = context.Owners.Find(owner.Id.Id) ?? new Context.Shop.Owner();

                Mapper.MapToDto(owner, dto);

                var id = dto.Id;

                if (context.Owners.Any(e => e.Id == id))
                {

                    context.Owners.Attach(dto);
                    context.OwnerAddresses.Attach(dto.OwnerAddress);

                    //TODO: multiplying phones
                    var phones = context.OwnerPhones.Where(p => p.OwnerId == id).ToList();

                    //Check phones to delete
                    foreach (var phone in phones)
                    {
                        if (
                            !dto.Phones.Any(
                                p => p.Country == phone.Country && p.Area == phone.Area && p.Number == phone.Number))
                        {
                            manager.ChangeObjectState(phone, EntityState.Deleted);
                        }
                    }
                    
                    //Check phones to add
                    foreach (var ownerPhone in dto.Phones)
                    {
                        var phone = context.OwnerPhones.Where(
                            p =>
                                p.Country == ownerPhone.Country && p.Area == ownerPhone.Area &&
                                p.Number == ownerPhone.Number);
                        if (
                            !phone.Any())
                        {
                            context.OwnerPhones.Add(ownerPhone);
                        }
                        else
                        {
                            context.Entry(phone.FirstOrDefault()).CurrentValues.SetValues(ownerPhone);
                        }

                    }

                    manager.ChangeObjectState(dto, EntityState.Modified);
                    manager.ChangeObjectState(dto.OwnerAddress, EntityState.Modified);
                }
                else
                {
                    context.Owners.Add(dto);
                }
                
                context.SaveChanges();
            }
        }

        public void Remove(Owner owner)
        {
            using (var context = new BakeryContext())
            {
                context.Owners.Remove(
                    context.Owners.Find(owner.Id.Id)
                );
            }
        }

        public OwnerId NextOwnerId()
        {
            return new OwnerId(Guid.NewGuid());
        }
    }
}
