using curriculum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace curriculum.Data
{
    public class CurriculumData : ICurriculumData
    {
        private readonly CurriculumContext _context;
        public CurriculumData(CurriculumContext context)
        {
            _context = context;
        }
        public Curriculum getCurriculumById(int userId, int curriculumId)
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
                .FirstOrDefault();
        }

        public Curriculum getCurriculumById(int curriculumId)
        {
            Curriculum curr = _context.Curriculums
                .Include(curr => curr.socialMedia)
                .Include(curr => curr.training)
                .ThenInclude(sm => sm.contents)
                .ThenInclude(con => con.subContents)
                .Include(curr => curr.userLanguageList)
                .ThenInclude(langs => langs.language)
                .ThenInclude(lang => lang.level)
                .Include(curr => curr.experience)
                .ThenInclude(exp => exp.contracts)
                .ThenInclude(contr => contr.proyects)
                .ThenInclude(proj => proj.descriptionList)
                .Include(curr => curr.otherData)
                .ThenInclude(od => od.values)
                .Where(curr => curr.id == curriculumId)
                .FirstOrDefault();
            curr.user = _context.User
                .Include(user => user.credentials)
                .Include(user => user.emailList)
                .Include(user => user.phoneNumber)
                .Where(user => user.id == curr.userId)
                .FirstOrDefault();
            return curr;
        }

        public IList<Curriculum> getCurriculumsByUserId(int userId)
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
                .Where(curr => curr.userId == userId)
                .ToList();
        }
    }
}
