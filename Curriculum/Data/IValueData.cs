using curriculum.Models;

namespace curriculum.Data
{
    public interface IValueData
    {
        public bool AddValue(ValueDto value);
        public bool UpdateValue(ValueDto value, int valueId);
    }
}
