using curriculum.Models;

namespace curriculum.Data
{
    public interface IExperienceData
    {
        public bool AddExperience(ExperienceDto experience);
        public bool UpdateExperience(ExperienceDto experience, int experienceId);
    }
}
