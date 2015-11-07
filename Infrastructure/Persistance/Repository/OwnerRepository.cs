using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Domain.Shop;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Mapper.Shop;
using Shared.Exceptions;
using Owner = Domain.Shop.Owner;

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
                var existingDto = context.Owners
                    .Include("Phones")
                    .Include("OwnerAddress")
                    .FirstOrDefault(o => o.Id == owner.Id.Id) ?? new Context.Shop.Owner();

                var newDto = Mapper.ToDto(owner);

                var id = newDto.Id;

                if (context.Owners.Any(e => e.Id == id))
                {
                    var updatedPhones = newDto.Phones.ToList();
                    var existingPhones = existingDto.Phones.ToList();

                    var addedPhones = updatedPhones.Except(existingPhones).ToList();
                    var deletedPhones = existingPhones.Except(updatedPhones).ToList();
                    var modifiedPhones = updatedPhones.Except(addedPhones).ToList();

                    addedPhones.ForEach(phn => context.Entry(phn).State = EntityState.Added);
                    deletedPhones.ForEach(phn => context.Entry(phn).State = EntityState.Deleted);

                    foreach (var phone in modifiedPhones)
                    {
                        var existingPhone = context.OwnerPhones
                            .FirstOrDefault(phn => phn.Equals(phone));

                        if (existingPhone == null)
                        {
                            continue;
                        }
                        var phoneEntry = context.Entry(existingPhone);
                        phoneEntry.CurrentValues.SetValues(phone);
                    }

                    var ownerEntry = context.Entry(existingDto);
                    ownerEntry.CurrentValues.SetValues(newDto);
                    var ownerAddressEntry = context.Entry(existingDto.OwnerAddress);
                    ownerAddressEntry.CurrentValues.SetValues(newDto.OwnerAddress);
                }
                else
                {
                    context.Owners.Add(newDto);
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                        
                    throw new RepositoryException(e.Message, e);
                }
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
