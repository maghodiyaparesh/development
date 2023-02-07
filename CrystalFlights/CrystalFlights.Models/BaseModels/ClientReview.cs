using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ClientReview")]
    public class ClientReview : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Review Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public long BrandId { get; set; }

        public string? ReviewType { get; set; }

        public double? Rating { get; set; } = 0.00;

        public string? Message { get; set; }

        public string? ReviewerName { get; set; }
    }
}
