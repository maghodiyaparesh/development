using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Roles")]
    public class Roles : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Role Id")]
        public long Id { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Role name is required")]
        public string? Name { get; set; }

        [Display(Name = "Role Code")]
        [Required(ErrorMessage = "Role code is required")]
        public string? Code { get; set; }

        public List<Features>? FeaturesList { get; set; }
    }
}
