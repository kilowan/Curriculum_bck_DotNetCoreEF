using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Contract : basebaseClass
    {
        public int experienceId { get; set; }


        [InverseProperty("contract")]
        public IList<Project> proyects { get; set; }

        [ForeignKey(nameof(Contract.experienceId))]
        public Experience experience { get; set; }
    }
}
