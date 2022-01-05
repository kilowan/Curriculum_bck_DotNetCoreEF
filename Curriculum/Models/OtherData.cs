using System.Collections.Generic;

namespace curriculum.Models
{
    public class OtherData
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Value> values { get; set; }
        public OtherData(Data.Models.OtherData otherData)
        {
            id = otherData.id;
            name = otherData.name;
            values = new List<Value>();
            foreach (Data.Models.Value value in otherData.values)
            {
                values.Add(new Value(value));
            }
        }
    }
}
