using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Mvc;

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
        public Curriculum Details(int id)
        {
            return curriculumBz.getCurriculumById(id);
        }
    }
}
