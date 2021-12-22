using System.Collections.Generic;

namespace curriculum.Models
{
    public class Content
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<string> subContents { get; set; }
        public Content(Data.Models.Content content)
        {
            id = content.id;
            name = content.name;
            subContents = new List<string>();
            foreach (Data.Models.SubContent subContent in content.subContents)
            {
                subContents.Add(subContent.name);
            }
        }
    }
}
