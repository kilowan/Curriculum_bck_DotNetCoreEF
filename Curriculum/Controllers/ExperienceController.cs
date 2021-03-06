using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Experience")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceBz experienceBz;
        public ExperienceController(IExperienceBz experienceBz)
        {
            this.experienceBz = experienceBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddExperience(ExperienceDto experience)
        {
            try
            {
                return experienceBz.AddExperience(experience);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{experienceId}")]
        [Authorize]
        public bool UpdateExperience(ExperienceDto experience, int experienceId)
        {
            try
            {
                return experienceBz.UpdateExperience(experience, experienceId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{experienceId}")]
        [Authorize]
        public bool DeleteExperience(int experienceId)
        {
            try
            {
                return experienceBz.DeleteExperience(experienceId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
