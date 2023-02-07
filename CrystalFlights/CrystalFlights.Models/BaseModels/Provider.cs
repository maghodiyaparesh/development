using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Provider")]
    public class Provider : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Provider Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public ProviderType ProviderType { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? CharCode { get; set; }

        public string? Address { get; set; }
        
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? WebsiteUrl { get; set; }

        public ProductType ProductType { get; set; }

        public string? MetaData { get; set; }
    }
}
