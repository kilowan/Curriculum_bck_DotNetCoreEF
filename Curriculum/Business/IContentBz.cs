using curriculum.Models;

namespace curriculum.Business
{
    public interface IContentBz
    {
        public bool UpdateContentById(int contentId, string content);
        public bool AddContent(ContentDto content);
    }
}
