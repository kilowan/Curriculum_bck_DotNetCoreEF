using curriculum.Models;

namespace curriculum.Business
{
    public interface IExperienceBz
    {
        public bool AddExperience(ExperienceDto experience);
        public bool UpdateExperience(ExperienceDto experience, int experienceId);
    }
}
