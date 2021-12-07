using System.Collections.Generic;

namespace curriculum.Models
{
    public class UserDto
    {
        public string name { get; set; }
        public string surname1 { get; set; }
        public string surname2 { get; set; }
        public Credentials credentials { get; set; }
        public IList<int> phoneNumbers { get; set; }
        public IList<string> emailList { get; set; }
    }
}
