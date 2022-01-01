using System.Collections.Generic;

namespace curriculum.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<string> descriptionList { get; set; }
        public Project(Data.Models.Project project)
        {
            id = project.id;
            name = project.name;
            descriptionList = new List<string>();
            foreach (Data.Models.Description description in project.descriptionList)
            {
                descriptionList.Add(description.name);
            }
        }
    }
}
