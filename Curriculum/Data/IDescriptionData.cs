using curriculum.Models;

namespace curriculum.Data
{
    public interface IDescriptionData
    {
        public bool AddDescription(DescriptionDto description);
        public bool UpdateDescription(DescriptionDto description, int descriptionId);
        public bool DeleteDescription(int descriptionId);
    }
}
