using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LanguageController
    {
        private Application.LanguageReadModel languageReadModel;

        public LanguageController()
        {
            languageReadModel = new Application.LanguageReadModel();
        }

        public string Get(string key)
        {

            return languageReadModel.Get(key);
        }
    }
}
