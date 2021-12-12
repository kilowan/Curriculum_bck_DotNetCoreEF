using curriculum.Data;
using curriculum.Models;
using System;
using System.Collections.Generic;

namespace curriculum.Business
{
    public class CurriculumBz : ICurriculumBz
    {
        private readonly ICurriculumData curriculumData;

        public CurriculumBz(ICurriculumData curriculumData)
        {
            this.curriculumData = curriculumData;
        }

        public Curriculum getCurriculumById(int userId, int curriculumId)
        {
            try
            {
                return new Curriculum(curriculumData.getCurriculumById(userId, curriculumId));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Curriculum getCurriculumById(int curriculumId)
        {
            try
            {
                return new Curriculum(curriculumData.getCurriculumById(curriculumId));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Curriculum> getCurriculumsByUserId(int userId)
        {
            try
            {
                IList<Curriculum> currls = new List<Curriculum>();
                foreach (Data.Models.Curriculum curriculum in curriculumData.getCurriculumsByUserId(userId))
                {
                    currls.Add(new Curriculum(curriculum));
                }
                return currls;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
