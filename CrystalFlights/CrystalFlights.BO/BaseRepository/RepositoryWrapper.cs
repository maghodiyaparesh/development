using CrystalFlights.Models;

namespace CrystalFlights.BO.BaseRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CFContext _repoContext;

        private readonly IAirportRepository _airport;
        private readonly IAirlineRepository _airline;
        private readonly IUsersRepository _users;

        public IAirportRepository Airport { get { return _airport ?? new AirportRepository(_repoContext); } }
        public IAirlineRepository Airline { get { return _airline ?? new AirlineRepository(_repoContext); } }
        public IUsersRepository Users { get { return _users ?? new UsersRepository(_repoContext); } }

        public RepositoryWrapper(CFContext cfContext)
        {
            _repoContext = cfContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
