using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ClinetEnquiry")]
    public class ClientEnquiry : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Enquiry Id")]
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Company { get; set; }

        public string? WebsiteUrl { get; set; }

        public string? Country { get; set; }

        public string? Message { get; set; }
    }
}
