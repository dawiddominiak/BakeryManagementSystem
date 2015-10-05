using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Settings
    {
        private static Settings instance;

        private Settings() 
        {
            //Default values
            CurrentLanguage = new Infrastructure.Languages.PolishPLLanguageStrategy();
        }

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }

                return instance;
            }
        }

        public Infrastructure.Languages.ILanguageStrategy CurrentLanguage { get; set; }
        public Shared.Structs.Currency DefaultCurrency { get; set; }
    }
}
