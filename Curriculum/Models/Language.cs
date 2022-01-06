namespace curriculum.Models
{
    public class Language
    {
        public int id { get; set; }
        public string name { get; set; }
        public Language(Data.Models.Language language)
        {
            id = language.id;
            name = language.name;
        }
    }
}
