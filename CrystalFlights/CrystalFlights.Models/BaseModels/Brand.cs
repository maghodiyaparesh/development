using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Brand")]
    public class Brand : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Brand Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Brand name is required")]
        public string? Name { get; set; }

        [Display(Name = "Brand Code")]
        [Required(ErrorMessage = "Brand code is required")]
        public string? Code { get; set; }

        public string? CharCode { get; set; }

        public ProductType ProductType { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
