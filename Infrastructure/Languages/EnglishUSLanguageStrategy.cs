namespace Infrastructure.Languages
{
    public class EnglishUsLanguageStrategy : ILanguageStrategy
    {
        public string GetValue(string key)
        {
            return en_US.resources.ResourceManager.GetString(key);
        }
    }
}
