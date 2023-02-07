using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_SiteSettings")]
    public class SiteSettings : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SiteSettings Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public string? Name { get; set; }
        
        public string? Code { get; set; }

        public string? Value { get; set; }
    }
}
