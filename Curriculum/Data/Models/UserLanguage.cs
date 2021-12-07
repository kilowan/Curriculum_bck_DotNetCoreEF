using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class UserLanguage : baseClass
    {
        public int languageId { get; set; }
        public int curriculumId { get; set; }

        [ForeignKey(nameof(UserLanguage.curriculumId))]
        public Curriculum curriculum { get; set; }

        [ForeignKey(nameof(UserLanguage.languageId))]
        public Language language { get; set; }
    }
}
