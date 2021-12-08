using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Curriculum : baseClass
    {
        public string description { get; set; }
        public int userId { get; set; }

        [InverseProperty("curriculum")]
        public IList<Experience> experience { get; set; }

        [InverseProperty("curriculum")]
        public IList<Training> training { get; set; }

        [InverseProperty("curriculum")]
        public IList<UserLanguage> userLanguageList { get; set; }

        [InverseProperty("curriculum")]
        public IList<SocialMedia> socialMedia { get; set; }

        [ForeignKey(nameof(Curriculum.userId))]
        public User user { get; set; }
    }
}
