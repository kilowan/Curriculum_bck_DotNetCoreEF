using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
    }
}
