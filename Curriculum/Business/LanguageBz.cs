using curriculum.Data;
using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public class LanguageBz : ILanguageBz
    {
        private readonly ILanguageData languageData;
        public LanguageBz(ILanguageData languageData)
        {
            this.languageData = languageData;
        }

        public bool AddLanguage(LanguageDto language)
        {
            try
            {
                return languageData.AddLanguage(language);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
