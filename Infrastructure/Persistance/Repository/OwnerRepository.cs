using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                var dto = context.Owners.Find(owner.Id.Id) ?? new Context.Shop.Owner();

                Mapper.MapToDto(owner, dto);

                context.Set<Context.Shop.Owner>().AddOrUpdate(dto);
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
