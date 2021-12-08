using System.Collections.Generic;

namespace curriculum.Models
{
    public class Contract
    {
        public string name { get; set; }
        public IList<Project> proyects { get; set; }

        public Contract(Data.Models.Contract contract)
        {
            name = contract.name;
            proyects = new List<Project>();
            foreach (Data.Models.Project project in contract.proyects)
            {
                proyects.Add(new Project(project));
            }
        }
    }
}
