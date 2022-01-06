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
        public bool UpdateValue(ValueDto value, int valueId)
        {
            try
            {
                bool result = false;
                Models.Value val = _context.Values
                    .Where(val => val.id == valueId)
                    .FirstOrDefault();
                val.name = !string.IsNullOrEmpty(value.name) ? value.name : null;
                _context.Values.Update(val);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteValue(int valueId)
        {
            try
            {
                bool result = false;
                Models.Value val = _context.Values
                    .Where(val => val.id == valueId)
                    .FirstOrDefault();
                _context.Values.Remove(val);
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
