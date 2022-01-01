using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class ExperienceBz : IExperienceBz
    {
        public readonly IExperienceData experienceData;
        public ExperienceBz(IExperienceData experienceData)
        {
            this.experienceData = experienceData;
        }

        public bool AddExperience(ExperienceDto experience)
        {
            try
            {
                return experienceData.AddExperience(experience);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
