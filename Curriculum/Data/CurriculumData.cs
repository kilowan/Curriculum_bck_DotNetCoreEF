using curriculum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Curriculum getCurriculumById(int curriculumId)
        {
            try
            {
                Curriculum curr = _context.Curriculums
                    .Include(curr => curr.email)
                    .Include(curr => curr.phoneNumber)
                    .Include(curr => curr.user)
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

                return curr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Curriculum> getCurriculumsByUserId(int userId)
        {
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
