using System.Collections.Generic;

namespace curriculum.Models
{
    public class OtherData
    {
        public string name { get; set; }
        public IList<string> values { get; set; }
        public OtherData(Data.Models.OtherData otherData)
        {
            name = otherData.name;
            values = new List<string>();
            foreach (Data.Models.Value value in otherData.values)
            {
                values.Add(value.name);
            }
        }
    }
}
