using curriculum.Models;

namespace curriculum.Business
{
    public interface IOtherBz
    {
        public bool AddOtherData(OtherDataDto otherData);
        public bool UpdateOtherData(OtherDataDto otherData, int otherDataId);
        public bool DeleteOtherData(int otherDataId);
    }
}
