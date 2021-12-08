using curriculum.Data;
using curriculum.Models;
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
            return new Curriculum(curriculumData.getCurriculumById(userId, curriculumId));
        }

        public Curriculum getCurriculumById(int curriculumId)
        {
            return new Curriculum(curriculumData.getCurriculumById(curriculumId));
        }

        public IList<Curriculum> getCurriculumsByUserId(int userId)
        {
            IList<Curriculum> currls = new List<Curriculum>();
            foreach (Data.Models.Curriculum curriculum in curriculumData.getCurriculumsByUserId(userId))
            {
                currls.Add(new Curriculum(curriculum));
            }
            return currls;
        }
    }
}
