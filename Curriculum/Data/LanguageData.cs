using curriculum.Models;
using System;
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
                    levelId = language.levelId,
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
                    languageId = langId
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
