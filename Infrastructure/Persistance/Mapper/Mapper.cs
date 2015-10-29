using System;

namespace Infrastructure.Persistance.Mapper
{
    public abstract class Mapper<TK, TV>
    {
        public abstract void MapToDto(TK domainObject, TV dto);
        public abstract void MapToDomainObject(TV dto, TK domainObject);

        public TV ToDto(TK domainObject)
        {
            var dto = (TV) Activator.CreateInstance(typeof (TV), new object[] {});
            MapToDto(domainObject, dto);
            return dto;
        }

        public TK ToDomainObject(TV dto)
        {
            var domainObject = (TK) Activator.CreateInstance(typeof (TK), new object[] {});
            MapToDomainObject(dto, domainObject);
            return domainObject;
        }

    }
}
