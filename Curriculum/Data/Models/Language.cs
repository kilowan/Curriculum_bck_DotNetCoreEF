using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Language : basebaseClass
    {
        public int levelId { get; set; }

        [ForeignKey(nameof(Language.levelId))]
        public LanguageLevel level { get; set; }
    }
}
