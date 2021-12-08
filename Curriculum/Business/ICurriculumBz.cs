using curriculum.Models;
using System.Collections.Generic;

namespace curriculum.Business
{
    public interface ICurriculumBz
    {
        public Curriculum getCurriculumById(int userId, int curriculumId);
        public Curriculum getCurriculumById(int curriculumId);
        public IList<Curriculum> getCurriculumsByUserId(int userId);
    }
}
