using curriculum.Data.Models;
using System.Collections.Generic;

namespace curriculum.Data
{
    public interface ICurriculumData
    {
        public Curriculum GetCurriculumById(int userId, int curriculumId);
        public Curriculum GetCurriculumById(int curriculumId);
        public IList<Curriculum> GetCurriculumsByUserId(int userId, string username);
        public bool DeleteCurriculum(int curriculumId);
    }
}
