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
                    initDate = experience.initDate,
                    finishDate = experience.finishDate,
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
    }
}
