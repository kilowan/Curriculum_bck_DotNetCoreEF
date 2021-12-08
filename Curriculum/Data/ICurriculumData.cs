using curriculum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public interface ICurriculumData
    {
        public IList<Curriculum> getCurriculum(int userId, int curriculumId);
    }
}
