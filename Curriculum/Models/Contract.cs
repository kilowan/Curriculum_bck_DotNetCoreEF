using System.Collections.Generic;

namespace curriculum.Models
{
    public class Contract
    {
        public string name { get; set; }
        public IList<Project> projects { get; set; }

        public Contract(Data.Models.Contract contract)
        {
            name = contract.name;
            projects = new List<Project>();
            foreach (Data.Models.Project project in contract.proyects)
            {
                projects.Add(new Project(project));
            }
        }
    }
}
