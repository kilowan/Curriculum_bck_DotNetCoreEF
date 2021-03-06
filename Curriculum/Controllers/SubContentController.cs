using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace curriculum.Controllers
{
    [Route("api/SubContent")]
    [ApiController]
    public class SubContentController : ControllerBase
    {
        private readonly ISubContentBz subContentBz;
        public SubContentController(ISubContentBz subContentBz)
        {
            this.subContentBz = subContentBz;
        }
        
        [HttpPost]
        [Authorize]
        public bool AddSubContents(SubContentsDto subContents)
        {
            try
            {
                return subContentBz.AddSubContents(subContents);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{subContentId}")]
        [Authorize]
        public bool DeleteSubContent(int subContentId)
        {
            try
            {
                return subContentBz.DeleteSubContent(subContentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
