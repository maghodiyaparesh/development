using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ClientPackage")]
    public class ClientPackage : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Package Id")]
        public long Id { get; set; }

        [Display(Name = "Package Name")]
        [Required(ErrorMessage = "Package name is required")]
        public string? Name { get; set; }

        [Display(Name = "Package Code")]
        [Required(ErrorMessage = "Package code is required")]
        public string? Code { get; set; }

        public string? Description { get; set; }

        public double Amount { get; set; } = 0.00;

        public int UserCount { get; set; } = 0;

        public int DaysCount { get; set; } = 0;

        public int BidsCount { get; set; } = 0;
    }
}
