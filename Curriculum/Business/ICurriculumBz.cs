using curriculum.Models;

namespace curriculum.Business
{
    public interface ICurriculumBz
    {
        public Curriculum getCurriculum(int userId, int curriculumId);
    }
}
