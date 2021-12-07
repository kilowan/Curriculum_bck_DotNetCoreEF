using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Training : basebaseClass
    {
        public int curriculumId { get; set; }
        public TrainingType type { get; set; }
        public string place { get; set; }
        public DateTime? initDatetime { get; set; }
        public DateTime? finishDateTime { get; set; }
        public DateTime? graduationDate { get; set; }

        [InverseProperty("training")]
        public IList<Content> contents { get; set; }

        [ForeignKey(nameof(Training.curriculumId))]
        public Curriculum curriculum { get; set; }
    }
}
