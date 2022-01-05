namespace curriculum.Models
{
    public class Description
    {
        public int id { get; set; }
        public string name { get; set; }
        public Description(Data.Models.Description description)
        {
            id = description.id;
            name = description.name;
        }
    }
}
