using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ClientOrder")]
    public class ClientOrder : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order Id")]
        public long Id { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public long PackageId { get; set; }

        public string? PackageName { get; set; }

        public string? PackageCode { get; set; }

        public string? Description { get; set; }

        public double PackageAmount { get; set; } = 0.00;

        public int UserCount { get; set; } = 0;

        public int DaysCount { get; set; } = 0;

        public int BidsCount { get; set; } = 0;

        public PaymentStatus PaymentStatus { get; set; } = 0;

        public string? DiscountCode { get; set; }

        public double DiscountAmount { get; set; } = 0.00;

        public double FinalAmount { get; set; } = 0.00;
    }
}
