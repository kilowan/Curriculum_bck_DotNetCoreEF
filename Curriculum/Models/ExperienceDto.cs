using curriculum.Data.Models;
using System;

namespace curriculum.Models
{
    public class ExperienceDto
    {
        public int curriculumId { get; set; }
        public string name { get; set; }
        public ExperienceType type { get; set; }
        public string place { get; set; }
        public DateTime initDate { get; set; }
        public DateTime finishDate { get; set; }
    }
}
