using System.ComponentModel.DataAnnotations.Schema;

namespace curriculum.Data.Models
{
    public class Description : basebaseClass
    {
        public int proyectId { get; set; }

        [ForeignKey(nameof(Description.proyectId))]
        public Project project { get; set; }
    }
}
