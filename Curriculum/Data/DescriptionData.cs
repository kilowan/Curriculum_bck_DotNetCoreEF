using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class DescriptionData : IDescriptionData
    {
        private readonly CurriculumContext _context;
        public DescriptionData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddDescription(DescriptionDto desciption)
        {
            try
            {
                bool result = false;
                int lastId = _context.Descriptions
                    .OrderBy(exp => exp.id)
                    .Select(exp => exp.id)
                    .LastOrDefault() + 1;

                _context.Descriptions.Add(new Models.Description()
                {
                    id = lastId,
                    proyectId = desciption.projectId,
                    name = desciption.name
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
