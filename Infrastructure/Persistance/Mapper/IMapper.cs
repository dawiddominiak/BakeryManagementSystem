namespace Infrastructure.Persistance.Mapper
{
    public interface IMapper<TK, TV>
    {
        TV ToDto(TK domainObject);

        TK ToDomainObject(TV dto);
    }
}
