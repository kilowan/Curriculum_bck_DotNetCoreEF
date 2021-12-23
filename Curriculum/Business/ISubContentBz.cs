using curriculum.Models;

namespace curriculum.Business
{
    public interface ISubContentBz
    {
        public bool AddSubContents(SubContentsDto subContents);
        public bool DeleteSubContent(int subContentId);
    }
}
