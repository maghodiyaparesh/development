using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.EntityFrameworkCore;

namespace CrystalFlights.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:MyConnection"];
            services.AddDbContext<CFContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("CrystalFlights.Api")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
