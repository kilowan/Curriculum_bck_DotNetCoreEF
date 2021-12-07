using curriculum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public class CurriculumData : ICurriculumData
    {
        private readonly CurriculumContext _context;
        public CurriculumData(CurriculumContext context)
        {
            _context = context;
        }
        public IList<Curriculum> getCurriculum(int userId, int curriculumId)
        {
            return _context.Curriculums
                .Include(curr => curr.socialMedia)
                .Include(curr => curr.training)
                .ThenInclude(sm => sm.contents)
                .ThenInclude(con => con.subContents)
                .Include(curr => curr.userLanguageList)
                .Include(curr => curr.experience)
                .ThenInclude(exp => exp.contracts)
                .ThenInclude(contr => contr.proyects)
                .ThenInclude(proj => proj.descriptionList)
                .Where(curr => curr.id == curriculumId && curr.userId == userId)
                .ToList();
        }
    }
}
