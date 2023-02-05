using Microsoft.EntityFrameworkCore;

namespace CrystalFlights.Models
{
    public class CFContext : DbContext
    {
        public CFContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Airport> Airport { get; set; }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
