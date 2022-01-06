namespace curriculum.Models
{
    public class UserLanguage
    {
        public int id { get; set; }
        public string name { get; set; }
        public LanguageLevel level { get; set; }
        public UserLanguage(Data.Models.UserLanguage userLanguage)
        {
            id = userLanguage.language.id;
            name = userLanguage.language.name;
            level = new LanguageLevel(userLanguage.level);
        }
    }
}
