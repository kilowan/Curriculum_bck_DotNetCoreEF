using curriculum.Models;

namespace curriculum.Data
{
    public interface ILanguageData
    {
        public bool AddLanguage(LanguageDto language);
        public bool UpdateLanguage(LanguageDto language, int languageId);
    }
}
