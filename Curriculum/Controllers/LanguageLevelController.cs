using curriculum.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace curriculum.Controllers
{
    [Route("api/LanguageLevel")]
    [ApiController]
    public class LanguageLevelController : ControllerBase
    {
        private readonly ILanguageLevelBz languageLevelBz;
        public LanguageLevelController(ILanguageLevelBz languageLevelBz)
        {
            this.languageLevelBz = languageLevelBz;
        }

        [HttpGet]
        [Authorize]
        public IList<Models.LanguageLevel> GetLanguageLevels()
        {
            try
            {
                return languageLevelBz.GetLanguageLevels();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
