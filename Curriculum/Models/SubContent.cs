namespace curriculum.Models
{
    public class SubContent
    {
        public int id { get; set; }
        public string name { get; set; }
        public SubContent(Data.Models.SubContent subContent)
        {
            id = subContent.id;
            name = subContent.name;
        }
    }
}
