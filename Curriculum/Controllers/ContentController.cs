using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPost]
        [Authorize]
        public bool AddContent(ContentDto content)
        {
            try
            {
                return contentBz.AddContent(content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
