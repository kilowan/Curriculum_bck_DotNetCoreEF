using curriculum.Data;
using curriculum.Models;
using System;

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
        public bool AddContent(ContentDto content)
        {
            try
            {
                return contentData.AddContent(content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteContent(int contentId) 
        {
            try
            {
                return contentData.DeleteContent(contentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
