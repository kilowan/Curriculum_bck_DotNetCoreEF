using curriculum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curriculum.Data
{
    public class LanguageLevelData : ILanguageLevelData
    {
        private readonly CurriculumContext _context;
        public LanguageLevelData(CurriculumContext context)
        {
            _context = context;
        }

        public IList<LanguageLevel> GetLanguageLevels()
        {
            try
            {
                return _context.LanguageLevels
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
