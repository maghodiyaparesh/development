using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_City")]
    public class City : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "City Id")]
        public long Id { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City name is required")]
        public string? Name { get; set; }

        [Display(Name = "City Code")]
        [Required(ErrorMessage = "City code is required")]
        public string? Code { get; set; }

        public string? StateCode { get; set; }

        public string? StateName { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public string? Continent { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public string? DisplayName { get; set; }
    }
}
