using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class SubContent : basebaseClass
    {
        public int contentId { get; set; }

        [ForeignKey(nameof(SubContent.contentId))]
        public Content Content { get; set; }
    }
}
