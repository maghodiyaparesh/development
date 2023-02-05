using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Airline")]
    public class Airline : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Airline Id")]
        public long AirlineId { get; set; }
        [Required(ErrorMessage = "Airline code is required")]
        public string? AirlineCode { get; set; }
        [Required(ErrorMessage = "Airline name is required")]
        public string? AirlineName { get; set; }
    }
}
