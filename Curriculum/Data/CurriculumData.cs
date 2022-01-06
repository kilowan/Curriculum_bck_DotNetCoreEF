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
        public Curriculum GetCurriculumById(int userId, int curriculumId)
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

        public Curriculum GetCurriculumById(int curriculumId)
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
                    .ThenInclude(ul => ul.level)
                    .Include(curr => curr.userLanguageList)
                    .ThenInclude(langs => langs.language)
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

        public IList<Curriculum> GetCurriculumsByUserId(int userId, string username)
        {
            try
            {
                return _context.Curriculums
                    .Include(curr => curr.user)
                    .ThenInclude(user => user.credentials)
                    .Where(curr => curr.userId == userId && curr.user.credentials.username == username)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteCurriculum(int curriculumId)
        {
            try
            {
                bool result = false;
                Models.Curriculum curr = _context.Curriculums
                    .Where(curr => curr.id == curriculumId)
                    .FirstOrDefault();
                _context.Curriculums.Remove(curr);
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
