namespace Infrastructure.Languages
{
    public interface ILanguageStrategy
    {
        string GetValue(string key);
    }
}
