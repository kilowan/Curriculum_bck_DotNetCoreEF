namespace curriculum.Models
{
    public class Curriculum
    {
        public string curriculumName { get; set; }
        public int curriculumId { get; set; }
        public Curriculum(Data.Models.Curriculum Curriculum)
        {
            curriculumName = Curriculum.name;
            curriculumId = Curriculum.id;
        }
    }
}
