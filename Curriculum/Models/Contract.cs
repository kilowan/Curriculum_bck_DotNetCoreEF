using System.Collections.Generic;

namespace curriculum.Models
{
    public class Contract
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Project> projects { get; set; }

        public Contract(Data.Models.Contract contract)
        {
            id = contract.id;
            name = contract.name;
            projects = new List<Project>();
            foreach (Data.Models.Project project in contract.proyects)
            {
                projects.Add(new Project(project));
            }
        }
    }
}
