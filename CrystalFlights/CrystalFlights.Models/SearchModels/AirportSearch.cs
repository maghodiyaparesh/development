namespace CrystalFlights.Models
{
    public class AirportSearch
    {
        public long AirportId { get; set; }
        public string? AirportCode { get; set; }
        public string? AirportName { get; set; }
        public string? AirportSearchText { get; set; }
        public bool? IsActive { get; set; }
    }
}
