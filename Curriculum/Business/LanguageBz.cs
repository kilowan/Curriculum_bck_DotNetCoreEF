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

        public IList<Language> GetLanguageList(int curriculumId)
        {
            IList<Language> langs = new List<Language>();
            foreach (Data.Models.Language lang in languageData.GetLanguageList(curriculumId))
            {
                langs.Add(new Language(lang));
            }

            return langs;
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

        public bool AddLanguage(int languageId, int curriculumId, int levelId)
        {
            try
            {
                return languageData.AddLanguage(languageId, curriculumId, levelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateLanguage(LanguageDto language, int languageId)
        {
            try
            {
                return languageData.UpdateLanguage(language, languageId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteLanguage(int languageId)
        {
            try
            {
                return languageData.DeleteLanguage(languageId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
