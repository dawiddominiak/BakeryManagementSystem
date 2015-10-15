namespace Infrastructure.Languages
{
    public class LanguagesStore
    {
        public ILanguageStrategy LanguageStrategy { private get; set; }

        public string GetValue(string key)
        {
            return LanguageStrategy.GetValue(key);
        }
    }
}
