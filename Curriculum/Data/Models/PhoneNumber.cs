using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class PhoneNumber :baseClass
    {
        public string prefix { get; set; }
        public int number { get; set; }
    }
}
