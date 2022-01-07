using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class SocialMedia : basebaseClass
    {
        public int curriculumId { get; set; }
        public int typeId { get; set; }

        [ForeignKey(nameof(SocialMedia.typeId))]
        public Data.Models.SocialMediaType type { get; set; }

        [ForeignKey(nameof(SocialMedia.curriculumId))]
        public Curriculum curriculum { get; set; }
    }
}
