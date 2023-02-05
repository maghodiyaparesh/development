using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    public class AirlineView : BaseModel
    {
        public long AirlineId { get; set; }
        [Required(ErrorMessage = "Airline code is required")]
        public string? AirlineCode { get; set; }
        [Required(ErrorMessage = "Airline name is required")]
        public string? AirlineName { get; set; }
    }
}
