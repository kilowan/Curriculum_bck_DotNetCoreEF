namespace curriculum.Models
{
    public class Language
    {
        public string name { get; set; }
        public LanguageLevel level { get; set; }
        public Language(Data.Models.Language language)
        {
            name = language.name;
            level = new LanguageLevel(language.level);
        }
    }
}
