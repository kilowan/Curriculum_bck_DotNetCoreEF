using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class DescriptionBz : IDescriptionBz
    {
        public readonly IDescriptionData descriptionData;
        public DescriptionBz(IDescriptionData descriptionData)
        {
            this.descriptionData = descriptionData;
        }

        public bool AddDescription(DescriptionDto description)
        {
            try
            {
                return descriptionData.AddDescription(description);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateDescription(DescriptionDto description, int descriptionId)
        {
            try
            {
                return descriptionData.UpdateDescription(description, descriptionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
