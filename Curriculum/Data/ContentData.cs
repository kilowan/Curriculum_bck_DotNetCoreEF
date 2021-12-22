using curriculum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public class ContentData : IContentData
    {
        private readonly CurriculumContext _context;
        public ContentData(CurriculumContext context)
        {
            _context = context;
        }
        public bool UpdateContentById(int contentId, string content) 
        {
            try
            {
                bool result = false;
                Content cont = _context.Contents
                    .Where(cont => cont.id == contentId)
                    .FirstOrDefault();
                if (cont != null)
                {
                    cont.name = content;
                    _context.Contents.Update(cont);
                    if (_context.SaveChanges() == 1) result = true;
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
