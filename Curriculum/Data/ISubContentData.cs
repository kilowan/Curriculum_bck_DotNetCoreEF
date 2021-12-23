using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public interface ISubContentData
    {
        public bool AddSubContents(SubContentsDto subContents);
        public bool DeleteSubContent(int subContentId);
    }
}
