using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class SocialMedia : basebaseClass
    {
        public int curriculumId { get; set; }
        public SocialMediaType type { get; set; }

        [ForeignKey(nameof(SocialMedia.curriculumId))]
        public Curriculum curriculum { get; set; }
    }
}
