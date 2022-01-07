using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace curriculum.Controllers
{
    [Route("api/SocialMediaType")]
    [ApiController]
    public class SocialMediaTypeController : ControllerBase
    {
        private readonly ISocialMediaTypeBz socialMediaTypeBz;
        public SocialMediaTypeController(ISocialMediaTypeBz socialMediaTypeBz)
        {
            this.socialMediaTypeBz = socialMediaTypeBz;
        }

        [HttpGet]
        [Authorize]
        public IList<SocialMediaType> GetSocialMediaTypeList()
        {
            try
            {
                return socialMediaTypeBz.GetSocialMediaTypeList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
