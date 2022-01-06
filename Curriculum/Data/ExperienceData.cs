using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class ExperienceData : IExperienceData
    {
        private readonly CurriculumContext _context;
        public ExperienceData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddExperience(ExperienceDto experience) 
        {
            try
            {
                bool result = false;
                int lastId = _context.Experiences
                    .OrderBy(exp => exp.id)
                    .Select(exp => exp.id)
                    .LastOrDefault() + 1;

                _context.Experiences.Add(new Models.Experience()
                {
                    initDate = (DateTime)experience.initDate,
                    finishDate = (DateTime)experience.finishDate,
                    curriculumId = experience.curriculumId,
                    id = lastId,
                    place = experience.place,
                    name = experience.name
                });

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdateExperience(ExperienceDto experience, int experienceId)
        {
            try
            {
                bool result = false;
                Models.Experience exp = _context.Experiences
                    .Where(exp => exp.id == experienceId)
                    .FirstOrDefault();
                exp.finishDate = experience.finishDate != null ? (DateTime)experience.finishDate : exp.finishDate;
                exp.initDate = experience.initDate != null ? (DateTime)experience.initDate : exp.initDate;
                exp.name =  !string.IsNullOrEmpty(experience.name) ? experience.name : exp.name;
                exp.place = !string.IsNullOrEmpty(experience.place) ? experience.place : exp.place;
                _context.Experiences.Update(exp);

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteExperience(int experienceId)
        {
            try
            {
                bool result = false;
                Models.Experience exp = _context.Experiences
                    .Where(exp => exp.id == experienceId)
                    .FirstOrDefault();
                _context.Experiences.Remove(exp);

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
