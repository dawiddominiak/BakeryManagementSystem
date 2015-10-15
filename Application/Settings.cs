namespace Application
{
    class Settings
    {
        private static Settings _instance;

        private Settings() 
        {
            //Default values
            CurrentLanguage = new Infrastructure.Languages.PolishPlLanguageStrategy();
        }

        public static Settings Instance
        {
            get
            {
                _instance = new Settings();
                return _instance;
            }
        }

        public Infrastructure.Languages.ILanguageStrategy CurrentLanguage { get; set; }
        public Shared.Structs.Currency DefaultCurrency { get; set; }
    }
}
