namespace CrystalFlights.Models
{
    public class UsersLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public bool IsRemember { get; set; } = false;
        public string RedirectUrl { get; set; }
    }
}
