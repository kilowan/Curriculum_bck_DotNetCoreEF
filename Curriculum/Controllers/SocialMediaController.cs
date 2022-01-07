using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/SocialMedia")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaBz socialMediaBz;
        public SocialMediaController(ISocialMediaBz socialMediaBz)
        {
            this.socialMediaBz = socialMediaBz;
        }

        [HttpPut("{socialMediaId}")]
        [Authorize]
        public bool UpdateSocialMedia(SocialMediaDto socialMedia, int socialMediaId)
        {
            try
            {
                return socialMediaBz.UpdateSocialMedia(socialMedia, socialMediaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
