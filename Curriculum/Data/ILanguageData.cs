using curriculum.Models;
using System.Collections.Generic;

namespace curriculum.Data
{
    public interface ILanguageData
    {
        public IList<Models.Language> GetLanguageList(int curriculumId);
        public bool AddLanguage(LanguageDto language);
        public bool AddLanguage(int languageId, int curriculumId, int levelId);
        public bool UpdateLanguage(LanguageDto language, int languageId);
        public bool DeleteLanguage(int languageId);
    }
}
