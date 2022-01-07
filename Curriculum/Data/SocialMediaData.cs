using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class SocialMediaData : ISocialMediaData
    {
        private readonly CurriculumContext _context;
        public SocialMediaData(CurriculumContext context)
        {
            _context = context;
        }

        public bool UpdateSocialMedia(SocialMediaDto socialMedia, int socialMediaId)
        {
            try
            {
                bool result = false;
                Models.SocialMedia sm = _context.SocialMedias
                    .Where(pr => pr.id == socialMediaId)
                    .FirstOrDefault();
                if(!string.IsNullOrEmpty(socialMedia.name))sm.name = socialMedia.name;
                if(socialMedia.typeId != 0) sm.typeId = socialMedia.typeId;
                _context.SocialMedias.Update(sm);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
