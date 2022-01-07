namespace curriculum.Models
{
    public class SocialMedia
    {
        public int id { get; set; }
        public string name { get; set; }
        public SocialMediaType type { get; set; }
        public SocialMedia(Data.Models.SocialMedia socialMedia)
        {
            id = socialMedia.id;
            name = socialMedia.name;
            type = new SocialMediaType(socialMedia.type);
        }
    }
}
