using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data.Models
{
    public class RecoverLog : baseClass
    {
        public string code { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public bool active { get; set; }

        [ForeignKey(nameof(RecoverLog.userId))]
        public User user { get; set; }
    }
}
