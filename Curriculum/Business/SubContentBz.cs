using curriculum.Data;
using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public class SubContentBz : ISubContentBz
    {
        private readonly ISubContentData subContentData;
        public SubContentBz(ISubContentData subContentData)
        {
            this.subContentData = subContentData;
        }

        public bool AddSubContents(SubContentsDto subContents) 
        {
            try
            {
                return subContentData.AddSubContents(subContents);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteSubContent(int subContentId) 
        {
            try
            {
                return subContentData.DeleteSubContent(subContentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
