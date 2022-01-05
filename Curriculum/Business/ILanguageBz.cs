using curriculum.Models;

namespace curriculum.Business
{
    public interface ILanguageBz
    {
        public bool AddLanguage(LanguageDto language);
        public bool UpdateLanguage(LanguageDto language, int languageId);
    }
}
