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

        public CurriculumDetail GetCurriculumById(int userId, int curriculumId)
        {
            try
            {
                return new CurriculumDetail(curriculumData.GetCurriculumById(userId, curriculumId));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CurriculumDetail GetCurriculumById(int curriculumId)
        {
            try
            {
                return new CurriculumDetail(curriculumData.GetCurriculumById(curriculumId));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Curriculum> GetCurriculumsByUserId(int userId, string username)
        {
            try
            {
                IList<Curriculum> currls = new List<Curriculum>();
                foreach (Data.Models.Curriculum curriculum in curriculumData.GetCurriculumsByUserId(userId, username))
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

        public bool DeleteCurriculum(int curriculumId)
        {
            try
            {
                return curriculumData.DeleteCurriculum(curriculumId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
