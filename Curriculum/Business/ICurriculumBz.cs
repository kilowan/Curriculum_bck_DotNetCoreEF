using curriculum.Models;
using System.Collections.Generic;

namespace curriculum.Business
{
    public interface ICurriculumBz
    {
        public CurriculumDetail GetCurriculumById(int userId, int curriculumId);
        public CurriculumDetail GetCurriculumById(int curriculumId);
        public IList<Curriculum> GetCurriculumsByUserId(int userId, string username);
    }
}
