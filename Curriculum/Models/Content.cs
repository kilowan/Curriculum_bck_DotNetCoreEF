using System.Collections.Generic;

namespace curriculum.Models
{
    public class Content
    {
        public string name { get; set; }
        public IList<string> subContents { get; set; }
        public Content(Data.Models.Content content)
        {
            name = content.name;
            subContents = new List<string>();
            foreach (Data.Models.SubContent subContent in content.subContents)
            {
                subContents.Add(subContent.name);
            }
        }
    }
}
