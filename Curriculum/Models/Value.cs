namespace curriculum.Models
{
    public class Value
    {
        public int id { get; set; }
        public string name { get; set; }
        public Value(Data.Models.Value value)
        {
            id = value.id;
            name = value.name;
        }
    }
}
