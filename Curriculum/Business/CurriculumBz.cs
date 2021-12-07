using curriculum.Data;
using curriculum.Models;

namespace curriculum.Business
{
    public class CurriculumBz : ICurriculumBz
    {
        private readonly ICurriculumData curriculumData;

        public CurriculumBz(ICurriculumData curriculumData)
        {
            this.curriculumData = curriculumData;
        }

        public Curriculum getCurriculum(int userId, int curriculumId)
        {
            return new Curriculum();
        }
    }
}
