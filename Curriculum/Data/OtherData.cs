using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class OtherData : IOtherData
    {
        private readonly CurriculumContext _context;
        public OtherData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddOtherData(OtherDataDto otherData)
        {
            try
            {
                bool result = false;
                int lastId = _context.Projects
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;

                _context.OtherDatas.Add(new Models.OtherData() 
                { 
                    id = lastId,
                    curriculumId = otherData.curriculumId,
                    name = otherData.name
                });
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateOtherData(OtherDataDto otherData, int otherDataId)
        {
            try
            {
                bool result = false;
                Models.OtherData other = _context.OtherDatas
                    .Where(od => od.id == otherDataId)
                    .FirstOrDefault();
                other.name = !string.IsNullOrEmpty(otherData.name)? otherData.name : null;
                _context.OtherDatas.Update(other);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteOtherData(int otherDataId)
        {
            try
            {
                bool result = false;
                Models.OtherData other = _context.OtherDatas
                    .Where(od => od.id == otherDataId)
                    .FirstOrDefault();
                _context.OtherDatas.Remove(other);
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
