using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public interface IAirlineRepository : IRepositoryBase<Airline>
    {
        IQueryable<Airline> FindByWhere(Expression<Func<Airline, bool>> expression);
        Task<IEnumerable<Airline>> GetAllAirlinesAsync();
        Task<IEnumerable<Airline>> GetAirlinesBySearchAsync(AirlineSearch airportSearch);
        Task<Airline> SaveAirline(Airline airport);
        Task<Airline> UpdateAirline(Airline airport);
        Task<Airline> DeleteAirline(Airline airport);
    }
}
