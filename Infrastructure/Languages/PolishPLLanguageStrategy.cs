namespace Infrastructure.Languages
{
    public class PolishPlLanguageStrategy : ILanguageStrategy
    {
        public string GetValue(string key)
        {
            return pl_PL.resources.ResourceManager.GetString(key);
        }
    }
}
