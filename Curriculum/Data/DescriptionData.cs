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

        public bool AddDescription(DescriptionDto description)
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
                    proyectId = description.projectId,
                    name = description.name
                });

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateDescription(DescriptionDto description, int descriptionId)
        {
            try
            {
                bool result = false;
                Models.Description desc = _context.Descriptions
                    .Where(desc => desc.id == descriptionId)
                    .FirstOrDefault();
                desc.name = description.name;
                _context.Descriptions.Update(desc);
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
