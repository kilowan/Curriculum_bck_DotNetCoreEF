using curriculum.Data.Models;

namespace curriculum.Models
{
    public class SocialMedia
    {
        public string name { get; set; }
        public SocialMediaType type { get; set; }
        public SocialMedia(Data.Models.SocialMedia socialMedia)
        {
            name = socialMedia.name;
            type = socialMedia.type;
        }
    }
}
