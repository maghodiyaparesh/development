using Microsoft.EntityFrameworkCore;

namespace CrystalFlights.Models
{
    public class CFContext : DbContext
    {
        public CFContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<ApiService> ApiService { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ClientCoupon> ClientCoupon { get; set; }
        public DbSet<ClientEnquiry> ClientEnquiry { get; set; }
        public DbSet<ClientOrder> ClientOrder { get; set; }
        public DbSet<ClientPackage> ClientPackage { get; set; }
        public DbSet<ClientReview> ClientReview { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CurrencyRate> CurrencyRate { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<FlightSearch> FlightSearch { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<PandaFlight> PandaFlight { get; set; }
        public DbSet<PandaFlightFare> PandaFlightFare { get; set; }
        public DbSet<PandaFlightSegment> PandaFlightSegment { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
