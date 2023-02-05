using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public class AirlineRepository : RepositoryBase<Airline>, IAirlineRepository
    {
        public AirlineRepository(CFContext cfContext) : base(cfContext) { }

        public IQueryable<Airline> FindByWhere(Expression<Func<Airline, bool>> expression)
        {
            return _cfContext.Set<Airline>().Where(expression);
        }

        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            return await FindAll()
                            .OrderBy(ow => ow.AirlineCode)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Airline>> GetAirlinesBySearchAsync(AirlineSearch airlineSearch)
        {
            var airlines = FindAll();

            if (airlineSearch.AirlineId > 0)
            {
                airlines = airlines.Where(a => a.AirlineId == airlineSearch.AirlineId);
            }
            if (!string.IsNullOrEmpty(airlineSearch.AirlineCode))
            {
                airlines = airlines.Where(a => a.AirlineCode.Equals(airlineSearch.AirlineCode));
            }
            if (!string.IsNullOrEmpty(airlineSearch.AirlineName))
            {
                airlines = airlines.Where(a => a.AirlineName.Equals(airlineSearch.AirlineName));
            }
            if (!string.IsNullOrEmpty(airlineSearch.AirlineSearchText))
            {
                airlines = airlines.Where(a =>
                                a.AirlineCode.Contains(airlineSearch.AirlineSearchText) ||
                                a.AirlineName.Contains(airlineSearch.AirlineSearchText)
                                );
            }
            if (airlineSearch.IsActive != null)
            {
                airlines = airlines.Where(a => a.IsActive == airlineSearch.IsActive);
            }

            if (airlines.Any())
                return await airlines.ToListAsync();
            else
                return null;
        }

        public async Task<Airline> SaveAirline(Airline airline)
        {
            await Task.Run(() => Create(airline));
            _cfContext.SaveChanges();

            return airline;
        }

        public async Task<Airline> UpdateAirline(Airline airline)
        {
            await Task.Run(() => Update(airline));
            _cfContext.SaveChanges();

            return airline;
        }

        public async Task<Airline> DeleteAirline(Airline airline)
        {
            airline.IsActive = false;

            await Task.Run(() => Update(airline));
            _cfContext.SaveChanges();

            return airline;
        }
    }
}
