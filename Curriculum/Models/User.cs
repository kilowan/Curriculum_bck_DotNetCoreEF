using curriculum.Data.Models;
using System.Collections.Generic;

namespace curriculum.Models
{
    public class User
    {
        public string name { get; set; }
        public string surname1 { get; set; }
        public string surname2 { get; set; }
        public int userId { get; set; }
        public Credentials credentials { get; set; }
        public IList<PhoneNumber> phoneNumbers { get; set; }
        public IList<Email> emailList { get; set; }

        public User(string name, string surname1, string surname2, Credentials credentials, IList<PhoneNumber> phoneNumbers, IList<Email> emailList)
        {
            this.name = name;
            this.surname1 = surname1;
            this.surname2 = surname2;
            this.credentials = credentials;
            this.phoneNumbers = phoneNumbers;
            this.emailList = emailList;
        }
        public User(string name, string surname1, string surname2, Credentials credentials)
        {
            this.name = name;
            this.surname1 = surname1;
            this.surname2 = surname2;
            this.credentials = credentials;
        }
        public User(string name, string surname1, string surname2)
        {
            this.name = name;
            this.surname1 = surname1;
            this.surname2 = surname2;
        }
        public User(string name, string surname1)
        {
            this.name = name;
            this.surname1 = surname1;
        }
        public User(string name, string surname1, Credentials credentials)
        {
            this.name = name;
            this.surname1 = surname1;
            this.credentials = credentials;
        }
        public User(string name, string surname1, Credentials credentials, IList<PhoneNumber> phoneNumbers, IList<Email> emailList)
        {
            this.name = name;
            this.surname1 = surname1;
            this.credentials = credentials;
            this.phoneNumbers = phoneNumbers;
            this.emailList = emailList;
        }
        public User(Data.Models.User user)
        {
            userId = user.id;
            name = user.name;
            surname1 = user.surname1;
            surname2 = user.surname2;
            credentials = new Credentials(user.credentials);
            phoneNumbers = new List<PhoneNumber>();
            foreach (UserNumber userNumber in user.phoneNumber)
            {
                phoneNumbers.Add(new PhoneNumber(userNumber.phone));
            }

            emailList = new List<Email>();
            foreach (Data.Models.Email email in user.emailList)
            {
                emailList.Add(new Email(email));
            }
        }
    }
}
