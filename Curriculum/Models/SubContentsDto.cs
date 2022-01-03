using System.Collections.Generic;

namespace curriculum.Models
{
    public class SubContentsDto
    {
        public int contentId { get; set; }
        public IList<string> subContents { get; set; }
    }
}
