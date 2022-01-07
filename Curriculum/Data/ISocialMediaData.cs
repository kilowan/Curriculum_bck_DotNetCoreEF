using curriculum.Models;

namespace curriculum.Data
{
    public interface ISocialMediaData
    {
        public bool UpdateSocialMedia(SocialMediaDto socialMedia, int socialMediaId);
    }
}
