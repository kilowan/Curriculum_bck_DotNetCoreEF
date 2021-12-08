using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Value : basebaseClass
    {
        public int OtherDataId { get; set; }

        [ForeignKey(nameof(Value.OtherDataId))]
        public OtherData other { get; set; }
    }
}
