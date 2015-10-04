using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class LanguageReadModel
    {
        public LanguageReadModel()
        {
            LanguageStore = new Infrastructure.Languages.LanguagesStore();
            LanguageStore.LanguageStrategy = Settings.Instance.CurrentLanguage;
        }

        public Infrastructure.Languages.LanguagesStore LanguageStore;

        public string Get(string key)
        {

            return LanguageStore.GetValue(key);
        }
    }
}
