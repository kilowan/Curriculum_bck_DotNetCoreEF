using System.Collections.Generic;

namespace curriculum.Models
{
    public class Curriculum
    {
        public string name { get; set; }
        public string description { get; set; }
        public IList<Experience> experience { get; set; }
        public IList<Training> training { get; set; }
        public IList<Language> languageList { get; set; }
        public IList<SocialMedia> socialMedia { get; set; }
        public IList<OtherData> otherData { get; set; }

        public Curriculum(Data.Models.Curriculum curriculum)
        {
            name = curriculum.name;
            description = curriculum.description;
            experience = new List<Experience>();
            foreach (Data.Models.Experience exp in curriculum.experience)
            {
                experience.Add(new Experience(exp));
            }

            training = new List<Training>();
            foreach (Data.Models.Training train in curriculum.training)
            {
                training.Add(new Training(train));
            }

            languageList = new List<Language>();
            foreach (Data.Models.UserLanguage userLang in curriculum.userLanguageList)
            {
                languageList.Add(new Language(userLang.language));
            }

            socialMedia = new List<SocialMedia>();
            foreach (Data.Models.SocialMedia social in curriculum.socialMedia)
            {
                socialMedia.Add(new SocialMedia(social));
            }

            otherData = new List<OtherData>();
            foreach (Data.Models.OtherData other in curriculum.otherData)
            {
                otherData.Add(new OtherData(other));
            }
        }
    }
}
