using curriculum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public class ContentBz : IContentBz
    {
        private readonly IContentData contentData;
        public ContentBz(IContentData contentData)
        {
            this.contentData = contentData;
        }

        public bool UpdateContentById(int contentId, string content) 
        {
            try
            {
                return contentData.UpdateContentById(contentId, content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
