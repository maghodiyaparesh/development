using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_PandaFlight")]
    public class PandaFlight : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Panda Flight Id")]
        public long Id { get; set; }
    }
}
