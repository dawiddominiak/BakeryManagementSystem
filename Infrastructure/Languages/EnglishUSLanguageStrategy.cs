using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Languages
{
    public class EnglishUSLanguageStrategy : ILanguageStrategy
    {
        public string GetValue(string key)
        {
            return en_US.resources.ResourceManager.GetString(key);
        }
    }
}
