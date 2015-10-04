using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Languages
{
    public class PolishPLLanguageStrategy : ILanguageStrategy
    {
        public string GetValue(string key)
        {
            return pl_PL.resources.ResourceManager.GetString(key);
        }
    }
}
