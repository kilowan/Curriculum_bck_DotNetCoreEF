using curriculum.Models;
using System.Collections.Generic;

namespace curriculum.Business
{
    public interface ICurriculumBz
    {
        public IList<Curriculum> getCurriculums(int userId, int curriculumId);
    }
}
