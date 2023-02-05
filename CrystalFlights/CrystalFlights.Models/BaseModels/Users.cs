using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Users")]
    public class Users : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Users Id")]
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; } = string.Empty;
        public string KeySalt { get; set; } = string.Empty;
    }
}
