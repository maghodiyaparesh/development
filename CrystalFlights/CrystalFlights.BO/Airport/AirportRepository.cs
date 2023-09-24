using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
    {
        public AirportRepository(CFContext cfContext) : base(cfContext) { }

        public IQueryable<Airport> FindByWhere(Expression<Func<Airport, bool>> expression)
        {
            return _cfContext.Set<Airport>().Where(expression);
        }

        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await FindAll()
                            .OrderBy(ow => ow.Code)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Airport>> GetAirportsBySearchAsync(AirportSearch airportSearch)
        {
            var airports = FindAll();

            if (airportSearch.AirportId > 0)
            {
                airports = airports.Where(a => a.Id == airportSearch.AirportId);
            }
            if (!string.IsNullOrEmpty(airportSearch.AirportCode))
            {
                airports = airports.Where(a => a.Code.Equals(airportSearch.AirportCode));
            }
            if (!string.IsNullOrEmpty(airportSearch.AirportName))
            {
                airports = airports.Where(a => a.Name.Equals(airportSearch.AirportName));
            }
            if (!string.IsNullOrEmpty(airportSearch.AirportSearchText))
            {
                airports = airports.Where(a =>
                                a.Code.Contains(airportSearch.AirportSearchText) ||
                                a.Name.Contains(airportSearch.AirportSearchText) ||
                                a.CityCode.Contains(airportSearch.AirportSearchText) ||
                                a.CityName.Contains(airportSearch.AirportSearchText)
                                );
            }
            if (airportSearch.IsActive != null)
            {
                airports = airports.Where(a => a.IsActive == airportSearch.IsActive);
            }

            if (airports.Any())
                return await airports.ToListAsync();
            else
                return null;
        }

        public async Task<Airport> SaveAirport(Airport airport)
        {
            await Task.Run(() => Create(airport));
            _cfContext.SaveChanges();

            return airport;
        }

        public async Task<Airport> UpdateAirport(Airport airport)
        {
            await Task.Run(() => Update(airport));
            _cfContext.SaveChanges();

            return airport;
        }

        public async Task<Airport> DeleteAirport(Airport airport)
        {
            airport.IsActive = false;

            await Task.Run(() => Update(airport));
            _cfContext.SaveChanges();

            return airport;
        }
    }
}
