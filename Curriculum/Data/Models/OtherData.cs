using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace curriculum.Data.Models
{
    public class OtherData : basebaseClass
    {
        public IList<Value> values { get; set; }
        public int curriculumId { get; set; }

        [ForeignKey(nameof(OtherData.curriculumId))]
        public Curriculum curriculum { get; set; }
    }
}
