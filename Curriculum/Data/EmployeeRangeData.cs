using curriculum.Data;

namespace Incidences.Data
{
    public class EmployeeRangeData //: IEmployeeRangeData
    {
        private readonly CurriculumContext _context;

        public EmployeeRangeData(CurriculumContext context)
        {
            _context = context;
        }

        /*public IList<TypeRange> SelectRangeList()
        {
            try
            {
                IList<employee_range> emras = _context.EmployeeRanges.ToList();
                IList<TypeRange> tyra = new List<TypeRange>();
                if (emras.Count > 0 )
                {
                    foreach (employee_range employee_range in emras)
                    {
                        tyra.Add(new TypeRange(employee_range.id, employee_range.name));
                    }
                } else throw new Exception("Ningún registro");

                return tyra;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public TypeRange SelectRangeById(int id)
        {
            try
            {
                employee_range emra = _context.EmployeeRanges
                    .Where(er => er.id == id)
                    .FirstOrDefault();
                return new TypeRange(id, emra.name);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int GetEmployeeRangeIdByName(string typeName)
        {
            return _context.EmployeeRanges
                .Where(er => er.name == typeName)
                .Select(er => er.id)
                .FirstOrDefault();
        }*/
    }
}
