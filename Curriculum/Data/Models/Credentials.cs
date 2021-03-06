using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class Credentials : baseClass
    {
        public string username { get; set; }
        public string password { get; set; }
        public int userId { get; set; }

        [ForeignKey(nameof(Credentials.userId))]
        public User user { get; set; }
    }
}
