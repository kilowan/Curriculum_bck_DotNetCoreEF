using curriculum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curriculum.Data
{
    public class SocialMediaTypeData : ISocialMediaTypeData
    {
        private readonly CurriculumContext _context;
        public SocialMediaTypeData(CurriculumContext context)
        {
            _context = context;
        }

        public IList<SocialMediaType> GetSocialMediaTypelist()
        {
            try
            {
                return _context.SocialMediaType
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
