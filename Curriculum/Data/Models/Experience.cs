using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Experience : basebaseClass
    {
        public int curriculumId { get; set; }
        public ExperienceType type { get; set; }
        public string place { get; set; }
        public DateTime initDate { get; set; }
        public DateTime? finishDate { get; set; }

        [InverseProperty("experience")]
        public IList<Contract> contracts { get; set; }

        [ForeignKey(nameof(Experience.curriculumId))]
        public Curriculum curriculum { get; set; }
    }
}
