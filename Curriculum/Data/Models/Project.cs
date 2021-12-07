using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Project : basebaseClass
    {
        public int contractId { get; set; }

        //[InverseProperty("proyect")]
        public IList<Description> descriptionList { get; set; }

        [ForeignKey(nameof(Project.contractId))]
        public Contract contract { get; set; }
    }
}
