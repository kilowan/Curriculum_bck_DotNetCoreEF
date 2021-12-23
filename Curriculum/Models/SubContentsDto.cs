using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Models
{
    public class SubContentsDto
    {
        public int contentId { get; set; }
        public IList<string> subContents { get; set; }
    }
}
