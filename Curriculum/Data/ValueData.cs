using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class ValueData : IValueData
    {
        private readonly CurriculumContext _context;
        public ValueData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddValue(ValueDto value)
        {
            try
            {
                bool result = false;
                int lastId = _context.Values
                    .OrderBy(val => val.id)
                    .Select(val => val.id)
                    .LastOrDefault() + 1;

                _context.Values.Add(new Models.Value() 
                { 
                    id = lastId,
                    name = value.name,
                    OtherDataId = value.otherDataId
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
