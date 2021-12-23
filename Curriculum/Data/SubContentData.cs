using curriculum.Data.Models;
using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SubContent = curriculum.Data.Models.SubContent;

namespace curriculum.Data
{
    public class SubContentData : ISubContentData
    {
        private readonly CurriculumContext _context;
        public SubContentData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddSubContents(SubContentsDto subContents) 
        {
            try
            {
                bool result = false;
                IList<SubContent> subs = new List<SubContent>();
                int lastId = _context.SubContents
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;
                foreach (string subContent in subContents.subContents)
                {
                    subs.Add(new SubContent()
                    {
                        contentId = subContents.contentId,
                        name = subContent,
                        id = lastId
                    });

                    lastId++;
                }

                _context.SubContents.AddRange(subs);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteSubContent(int subContentId)
        {
            try
            {
                bool result = false;

                SubContent sub = _context.SubContents
                    .Where(sub => sub.id == subContentId)
                    .FirstOrDefault();
                _context.SubContents.Remove(sub);
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
