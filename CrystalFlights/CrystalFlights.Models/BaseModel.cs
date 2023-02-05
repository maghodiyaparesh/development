namespace CrystalFlights.Models
{
    public class BaseModel
    {
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public long ModifiedBy { get; set; }
    }
}
