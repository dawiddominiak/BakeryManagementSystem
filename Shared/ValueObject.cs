namespace Shared
{
    public interface IValueObject<in T>
    {
        bool SameValueAs(T other);
    }
}
