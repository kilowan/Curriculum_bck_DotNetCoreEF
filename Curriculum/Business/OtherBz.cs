using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class OtherBz : IOtherBz
    {
        private readonly IOtherData otherData;
        public OtherBz(IOtherData otherData)
        {
            this.otherData = otherData;
        }

        public bool AddOtherData(OtherDataDto otherData)
        {
            try
            {
                return this.otherData.AddOtherData(otherData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
