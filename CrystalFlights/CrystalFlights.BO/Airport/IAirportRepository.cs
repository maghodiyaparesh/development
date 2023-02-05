using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public interface IAirportRepository : IRepositoryBase<Airport>
    {
        IQueryable<Airport> FindByWhere(Expression<Func<Airport, bool>> expression);
        Task<IEnumerable<Airport>> GetAllAirportsAsync();
        Task<IEnumerable<Airport>> GetAirportsBySearchAsync(AirportSearch airportSearch);
        Task<Airport> SaveAirport(Airport airport);
        Task<Airport> UpdateAirport(Airport airport);
        Task<Airport> DeleteAirport(Airport airport);
    }
}
