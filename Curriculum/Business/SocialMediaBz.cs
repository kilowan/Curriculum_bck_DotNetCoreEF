using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class SocialMediaBz : ISocialMediaBz
    {
        private readonly ISocialMediaData socialMediaData;
        public SocialMediaBz(ISocialMediaData socialMediaData)
        {
            this.socialMediaData = socialMediaData;
        }

        public bool UpdateSocialMedia(SocialMediaDto socialMedia, int socialMediaId)
        {
            try
            {
                return socialMediaData.UpdateSocialMedia(socialMedia, socialMediaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
