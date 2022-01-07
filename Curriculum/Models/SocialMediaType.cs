namespace curriculum.Models
{
    public class SocialMediaType
    {
        public int id { get; set; }
        public string name { get; set; }
        public SocialMediaType(Data.Models.SocialMediaType socialMediaType)
        {
            id = socialMediaType.id;
            name = socialMediaType.name;
        }
    }
}
