using curriculum.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Controllers
{
    [Route("api/Content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentBz contentBz;
        public ContentController(IContentBz contentBz)
        {
            this.contentBz = contentBz;
        }

        [HttpPut("{contentId}/{content}")]
        [Authorize]
        public bool UpdateByContentId(int contentId, string content)
        {
            try
            {
                return contentBz.UpdateContentById(contentId, content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
