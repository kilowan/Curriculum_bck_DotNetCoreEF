using curriculum.Models;

namespace curriculum.Business
{
    public interface IDescriptionBz
    {
        public bool AddDescription(DescriptionDto description);
        public bool UpdateDescription(DescriptionDto description, int descriptionId);
    }
}
