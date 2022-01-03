namespace curriculum.Models
{
    public class LanguageLevel
    {
        public int id { get; set; }
        public string name { get; set; }
        public LanguageLevel(Data.Models.LanguageLevel languageLevel)
        {
            id = languageLevel.id;
            name = languageLevel.name;
        }
    }
}
