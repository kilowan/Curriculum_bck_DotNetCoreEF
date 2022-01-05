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
    }
}
