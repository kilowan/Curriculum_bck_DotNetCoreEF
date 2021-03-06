using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class ValueBz : IValueBz
    {
        private readonly IValueData valueData;
        public ValueBz(IValueData valueData)
        {
            this.valueData = valueData;
        }

        public bool AddValue(ValueDto value)
        {
            try
            {
                return valueData.AddValue(value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateValue(ValueDto value, int valueId)
        {
            try
            {
                return valueData.UpdateValue(value, valueId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteValue(int valueId)
        {
            try
            {
                return valueData.DeleteValue(valueId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
