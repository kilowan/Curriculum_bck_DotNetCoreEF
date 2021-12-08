using System.Collections.Generic;
using System.Linq;

namespace curriculum.Models
{
    public class Curriculum
    {
        public string curriculumName { get; set; }
        public string description { get; set; }
        public string fullName { get; set; }
        public IList<PhoneNumber> phoneNumbers { get; set; }
        public IList<Email> emailList { get; set; }
        public IList<Experience> experience { get; set; }
        public IList<Training> otherTraining { get; set; }
        public IList<Training> academicTraining { get; set; }
        public IList<Language> languageList { get; set; }
        public IList<SocialMedia> socialMedia { get; set; }
        public IList<OtherData> otherData { get; set; }

        public Curriculum(Data.Models.Curriculum curriculum)
        {
            curriculumName = curriculum.name;
            fullName = $"{curriculum.user.name} {curriculum.user.surname1} {curriculum.user.surname2}";
            phoneNumbers = new List<PhoneNumber>();
            foreach (Data.Models.UserNumber userNumber in curriculum.user.phoneNumber)
            {
                phoneNumbers.Add(new PhoneNumber(userNumber.phone));
            }

            emailList = new List<Email>();
            foreach (Data.Models.Email email in curriculum.user.emailList)
            {
                emailList.Add(new Email(email));
            }
            description = curriculum.description;
            experience = new List<Experience>();
            foreach (Data.Models.Experience exp in curriculum.experience)
            {
                experience.Add(new Experience(exp));
            }

            IList<Data.Models.Training> academic = curriculum.training
                .Where(tr => tr.type == Data.Models.TrainingType.academic)
                .ToList();
            IList<Data.Models.Training> others = curriculum.training
                .Where(tr => tr.type == Data.Models.TrainingType.other)
                .ToList();
            academicTraining = new List<Training>();
            foreach (Data.Models.Training train in academic)
            {
                academicTraining.Add(new Training(train));
            }

            otherTraining = new List<Training>();
            foreach (Data.Models.Training train in others)
            {
                otherTraining.Add(new Training(train));
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
