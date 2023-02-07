using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_ClientCoupon")]
    public class ClientCoupon : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Coupon Id")]
        public long Id { get; set; }

        [Display(Name = "Coupon Name")]
        [Required(ErrorMessage = "Coupon name is required")]
        public string? Name { get; set; }

        [Display(Name = "Coupon Code")]
        [Required(ErrorMessage = "Coupon code is required")]
        public string? Code { get; set; }

        public AmountType AmountType { get; set; } = 0;

        public double Amount { get; set; }

        public int UserCount { get; set; }
    }
}
