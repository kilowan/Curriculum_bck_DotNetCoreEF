using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class UserNumber : baseClass
    {
        public int userId { get; set; }
        public int phoneId { get; set; }

        [ForeignKey(nameof(UserNumber.phoneId))]
        public PhoneNumber phone { get; set; }

        [ForeignKey(nameof(UserNumber.userId))]
        public User user { get; set; }
    }
}
