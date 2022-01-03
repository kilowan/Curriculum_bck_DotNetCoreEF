using curriculum.Data;
using curriculum.Data.Models;
using System;
using System.Collections.Generic;

namespace curriculum.Business
{
    public class LanguageLevelBz : ILanguageLevelBz
    {
        private readonly ILanguageLevelData languageLevelData;
        public LanguageLevelBz(ILanguageLevelData languageLevelData)
        {
            this.languageLevelData = languageLevelData;
        }

        public IList<Models.LanguageLevel> GetLanguageLevels()
        {
            try
            {
                IList<Models.LanguageLevel> languageLevelList = new List<Models.LanguageLevel>();
                foreach (LanguageLevel languageLevel in languageLevelData.GetLanguageLevels())
                {
                    languageLevelList.Add(new(languageLevel));
                }

                return languageLevelList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
