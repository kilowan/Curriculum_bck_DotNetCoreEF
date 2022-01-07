using curriculum.Data.Models;
using System.Collections.Generic;

namespace curriculum.Data
{
    public interface ISocialMediaTypeData
    {
        public IList<SocialMediaType> GetSocialMediaTypelist();
    }
}
