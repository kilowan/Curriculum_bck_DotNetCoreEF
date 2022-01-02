using curriculum.Data.Models;
using System;

namespace curriculum.Models
{
    public class TrainingDto
    {
        public int curriculumId { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public DateTime? initDateTime { get; set; }
        public DateTime? finishDateTime { get; set; }
        public DateTime? graduationDate { get; set; }
        public TrainingType type { get; set; }
    }
}
