using curriculum.Models;

namespace curriculum.Data
{
    public interface IOtherData
    {
        public bool AddOtherData(OtherDataDto otherData);
        public bool UpdateOtherData(OtherDataDto otherData, int otherDataId);
    }
}
