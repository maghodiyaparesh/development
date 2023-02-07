using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ApiService")]
    public class ApiService : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ApiService Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public string? ClientCode { get; set; }

        public long BrandId { get; set; }

        public string? BrandCode { get; set; }

        public ProductType ProductType { get; set; }

        public long ProviderId { get; set; }

        public string? ProviderCode { get; set; }

        public long VendorId { get; set; }

        public string? VendorCode { get; set; }

        public string? ApiKey { get; set; }
    }
}
