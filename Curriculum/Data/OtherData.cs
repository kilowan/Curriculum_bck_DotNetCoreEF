﻿using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class OtherData : IOtherData
    {
        private readonly CurriculumContext _context;
        public OtherData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddOtherData(OtherDataDto otherData)
        {
            try
            {
                bool result = false;
                int lastId = _context.Projects
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;

                _context.OtherDatas.Add(new Models.OtherData() 
                { 
                    id = lastId,
                    curriculumId = otherData.curriculumId,
                    name = otherData.name
                });
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
