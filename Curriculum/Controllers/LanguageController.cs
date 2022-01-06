using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace curriculum.Controllers
{
    [Route("api/Language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageBz languageBz;
        public LanguageController(ILanguageBz languageBz)
        {
            this.languageBz = languageBz;
        }

        [HttpGet("{curriculumId}")]
        [Authorize]
        public IList<Language> GetLanguageList(int curriculumId)
        {
            try
            {
                return languageBz.GetLanguageList(curriculumId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public bool AddLanguage(LanguageDto language)
        {
            try
            {
                return languageBz.AddLanguage(language);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut("{languageId}/{curriculumId}/{levelId}")]
        [Authorize]
        public bool AddLanguage(int languageId, int curriculumId, int levelId)
        {
            try
            {
                return languageBz.AddLanguage(languageId, curriculumId, levelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{languageId}")]
        [Authorize]
        public bool UpdateLanguage(LanguageDto language, int languageId)
        {
            try
            {
                return languageBz.UpdateLanguage(language, languageId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{languageId}")]
        [Authorize]
        public bool DeleteLanguage(int languageId)
        {
            try
            {
                return languageBz.DeleteLanguage(languageId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
