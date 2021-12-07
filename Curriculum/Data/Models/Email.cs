using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class Email : basebaseClass
    {
        public string domain { get; set; }
        public int userId { get; set; }

        [ForeignKey(nameof(Email.userId))]
        public User user { get; set; }
    }
}
