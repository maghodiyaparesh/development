using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_CurrencyRate")]
    public class CurrencyRate : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CurrencyRate Id")]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public string? CurrencyCode { get; set; }

        public double Value { get; set; }
    }
}
