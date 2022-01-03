using curriculum.Data.Models;
using System.Collections.Generic;

namespace curriculum.Data
{
    public interface ILanguageLevelData
    {
        public IList<LanguageLevel> GetLanguageLevels();
    }
}
