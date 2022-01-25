using curriculum.Data.Models;
using System;
using System.Collections.Generic;

namespace curriculum.Models
{
    public class Experience
    {
        public int id { get; set; }
        public string name { get; set; }
        public ExperienceType type { get; set; }
        public string place { get; set; }
        public DateTime initDate { get; set; }
        public DateTime? finishDate { get; set; }
        public IList<Contract> contracts { get; set; }
        public Experience(Data.Models.Experience experience)
        {
            id = experience.id;
            name = experience.name;
            type = experience.type;
            place = experience.place;
            initDate = experience.initDate;
            finishDate = experience.finishDate;
            contracts = new List<Contract>();
            foreach (Data.Models.Contract contract in experience.contracts)
            {
                contracts.Add(new Contract(contract));
            }
        }
    }
}
