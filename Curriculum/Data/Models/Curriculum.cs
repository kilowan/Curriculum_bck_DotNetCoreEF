using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Curriculum : basebaseClass
    {
        public string description { get; set; }
        public int userId { get; set; }
        public int phoneId { get; set; }
        public int emailId { get; set; }

        [InverseProperty("curriculum")]
        public IList<Experience> experience { get; set; }

        [InverseProperty("curriculum")]
        public IList<Training> training { get; set; }

        [InverseProperty("curriculum")]
        public IList<UserLanguage> userLanguageList { get; set; }

        [InverseProperty("curriculum")]
        public IList<SocialMedia> socialMedia { get; set; }

        [InverseProperty("curriculum")]
        public IList<OtherData> otherData { get; set; }

        [ForeignKey(nameof(Curriculum.userId))]
        public User user { get; set; }

        [ForeignKey(nameof(Curriculum.phoneId))]
        public PhoneNumber phoneNumber { get; set; }

        [ForeignKey(nameof(Curriculum.emailId))]
        public Email email { get; set; }
    }
}
