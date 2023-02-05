namespace CrystalFlights.Models
{
    public class AirlineSearch
    {
        public long AirlineId { get; set; }
        public string? AirlineCode { get; set; }
        public string? AirlineName { get; set; }
        public string? AirlineSearchText { get; set; }
        public bool? IsActive { get; set; }
    }
}
