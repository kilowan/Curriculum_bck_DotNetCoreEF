using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class User: basebaseClass
    {
        public string surname1 { get; set; }
        public string surname2 { get; set; }
        public Credentials credentials { get; set; }

        [InverseProperty("user")]
        public IList<UserNumber> phoneNumber { get; set; }

        [InverseProperty("user")]
        public IList<Email> emailList { get; set; }

        [InverseProperty("user")]
        public IList<Curriculum> curriculums { get; set; }


    }
}
