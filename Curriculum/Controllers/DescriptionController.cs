using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Description")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionBz descriptionBz;
        public DescriptionController(IDescriptionBz descriptionBz)
        {
            this.descriptionBz = descriptionBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddDescription(DescriptionDto description)
        {
            try
            {
                return descriptionBz.AddDescription(description);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{descriptionId}")]
        [Authorize]
        public bool UpdateDescription(DescriptionDto description, int descriptionId)
        {
            try
            {
                return descriptionBz.UpdateDescription(description, descriptionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{descriptionId}")]
        [Authorize]
        public bool DeleteDescription(int descriptionId)
        {
            try
            {
                return descriptionBz.DeleteDescription(descriptionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
