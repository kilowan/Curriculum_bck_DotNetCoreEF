using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace curriculum.Controllers
{
    [Route("api/Curriculum")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumBz curriculumBz;
        public CurriculumController(ICurriculumBz curriculumBz)
        {
            this.curriculumBz = curriculumBz;
        }

        [HttpGet("{id}")]
        [Authorize]
        public CurriculumDetail Details(int id)
        {
            try
            {
                return curriculumBz.GetCurriculumById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{userId}/{username}")]
        [Authorize]
        public IList<Curriculum> GetCurriculumsByUserId(int userId, string username)
        {
            try
            {
                return curriculumBz.GetCurriculumsByUserId(userId, username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
