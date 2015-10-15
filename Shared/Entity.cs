namespace Shared
{
    public interface IEntity<in T>
    {
        bool SameIdentityAs(T other);
    }
}
