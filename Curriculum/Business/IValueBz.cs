using curriculum.Models;

namespace curriculum.Business
{
    public interface IValueBz
    {
        public bool AddValue(ValueDto value);
        public bool UpdateValue(ValueDto value, int valueId);
    }
}
