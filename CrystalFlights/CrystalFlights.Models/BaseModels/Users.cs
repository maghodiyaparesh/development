using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrystalFlights.Models
{
    [Table("dr_Users")]
    public class Users : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Id")]
        public long Id { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "User role is required")]
        public long RoleId { get; set; }

        [Display(Name = "Client Code")]
        public string? ClientCode { get; set; }

        [Display(Name = "Display Name")]
        public string? DisplayName { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        public DateTime PasswordExpiry { get; set; }
        
        public int LoginAttempt { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public string? CreatedIp { get; set; }

        public string? Session { get; set; }

        [Display(Name = "Key Salt")]
        public string KeySalt { get; set; } = string.Empty;

        public UserStatus UserStatus { get; set; }
    }
}
