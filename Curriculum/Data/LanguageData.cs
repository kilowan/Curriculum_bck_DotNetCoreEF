using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curriculum.Data
{
    public class LanguageData : ILanguageData
    {
        private readonly CurriculumContext _context;
        public LanguageData(CurriculumContext context)
        {
            _context = context;
        }

        public IList<Models.Language> GetLanguageList(int curriculumId)
        {
            try
            {
                IList<int> ids = _context.UserLanguages
                    .Where(ul => ul.curriculumId == curriculumId)
                    .Select(ul => ul.id)
                    .ToList();

                return _context.Languages
                    .Where(lang => !ids.Contains(lang.id))
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool AddLanguage(LanguageDto language)
        {
            try
            {
                bool result = false;
                int langId = _context.Languages
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;

                _context.Languages.Add(new Models.Language() 
                { 
                    id = langId,
                    name = language.name
                });
                _context.SaveChanges();

                int lastId = _context.UserLanguages
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;
                _context.UserLanguages.Add(new Models.UserLanguage()
                {
                    id = lastId,
                    curriculumId = language.curriculumId,
                    languageId = langId,
                    levelId = language.levelId
                });

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool AddLanguage(int languageId, int curriculumId, int levelId)
        {
            try
            {
                bool result = false;
                int lastId = _context.UserLanguages
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;
                _context.UserLanguages.Add(new Models.UserLanguage()
                {
                    id = lastId,
                    curriculumId = curriculumId,
                    languageId = languageId,
                    levelId = levelId
                });

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateLanguage(LanguageDto language, int languageId)
        {
            try
            {
                bool result = false;
                Models.Language lg = _context.Languages
                    .Where(lg => lg.id == languageId)
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(language.name)) lg.name =  language.name;
                _context.Languages.Update(lg);
                Models.UserLanguage ul = _context.UserLanguages
                    .Where(ul => ul.id == languageId)
                    .FirstOrDefault();
                if(language.levelId != 0) ul.levelId = language.levelId;
                _context.UserLanguages.Update(ul);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteLanguage(int languageId)
        {
            try
            {
                bool result = false;
                Models.UserLanguage lg = _context.UserLanguages
                    .Where(lg => lg.id == languageId)
                    .FirstOrDefault();
                _context.UserLanguages.Remove(lg);
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
