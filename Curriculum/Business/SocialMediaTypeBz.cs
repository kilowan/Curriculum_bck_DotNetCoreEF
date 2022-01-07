using curriculum.Data;
using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public class SocialMediaTypeBz : ISocialMediaTypeBz
    {
        private readonly ISocialMediaTypeData socialMediaTypeData;
        public SocialMediaTypeBz(ISocialMediaTypeData socialMediaTypeData)
        {
            this.socialMediaTypeData = socialMediaTypeData;
        }

        public IList<SocialMediaType> GetSocialMediaTypeList()
        {
            try
            {
                IList<SocialMediaType> somety = new List<SocialMediaType>();
                foreach (Data.Models.SocialMediaType smt in socialMediaTypeData.GetSocialMediaTypelist())
                {
                    somety.Add(new SocialMediaType(smt));
                }

                return somety;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
