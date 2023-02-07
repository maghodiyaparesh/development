using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Features")]
    public class Features : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Feature Id")]
        public long Id { get; set; }

        [Display(Name = "Feature Name")]
        [Required(ErrorMessage = "Feature name is required")]
        public string? Name { get; set; }

        [Display(Name = "Feature Code")]
        [Required(ErrorMessage = "Feature code is required")]
        public string? Code { get; set; }

        public FeatureType? FeatureType { get; set; }
    }
}
