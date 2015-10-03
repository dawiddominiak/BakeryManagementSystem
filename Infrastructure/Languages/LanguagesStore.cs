using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
