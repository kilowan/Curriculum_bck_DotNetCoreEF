using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class UserLanguage : baseClass
    {
        public int languageId { get; set; }
        public int curriculumId { get; set; }
        public int levelId { get; set; }
        [ForeignKey(nameof(UserLanguage.curriculumId))]
        public Curriculum curriculum { get; set; }

        [ForeignKey(nameof(UserLanguage.languageId))]
        public Language language { get; set; }

        [ForeignKey(nameof(UserLanguage.levelId))]
        public LanguageLevel level { get; set; }
    }
}
