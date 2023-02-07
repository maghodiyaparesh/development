using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Country")]
    public class Country : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Country Id")]
        public long Id { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country name is required")]
        public string? Name { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Country code is required")]
        public string? Code { get; set; }
    }
}
