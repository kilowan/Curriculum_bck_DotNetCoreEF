using curriculum.Models;

namespace curriculum.Data
{
    public interface IContentData
    {
        public bool UpdateContentById(int contentId, string content);
        public bool AddContent(ContentDto content);
    }
}
