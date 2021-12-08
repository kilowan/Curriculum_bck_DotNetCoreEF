using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Content : basebaseClass
    {
        public int trainingId { get; set; }

        [ForeignKey(nameof(Content.trainingId))]
        public Training training { get; set; }
        public IList<SubContent> subContents { get; set; }
    }
}
