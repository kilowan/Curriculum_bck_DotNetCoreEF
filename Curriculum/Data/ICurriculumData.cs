using curriculum.Data.Models;
using System.Collections.Generic;

namespace curriculum.Data
{
    public interface ICurriculumData
    {
        public Curriculum getCurriculumById(int userId, int curriculumId);
        public Curriculum getCurriculumById(int curriculumId);
        public IList<Curriculum> getCurriculumsByUserId(int userId);
    }
}
