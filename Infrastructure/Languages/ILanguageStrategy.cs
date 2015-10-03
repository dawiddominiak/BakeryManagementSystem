using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Languages
{
    public interface ILanguageStrategy
    {
        string GetValue(string key);
    }
}
