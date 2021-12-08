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

        public IList<Curriculum> getCurriculums(int userId, int curriculumId)
        {
            IList <Curriculum> curriculumList = new List<Curriculum>();
            IList<Data.Models.Curriculum> curriculums = curriculumData.getCurriculum(userId, curriculumId);
            foreach (Data.Models.Curriculum curriculum in curriculums)
            {
                curriculumList.Add(new Curriculum(curriculum));
            }
            return curriculumList;
        }
    }
}
