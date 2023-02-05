namespace CrystalFlights.BO.BaseRepository
{
    public interface IRepositoryWrapper
    {
        IAirportRepository Airport { get; }
        IAirlineRepository Airline { get; }
        IUsersRepository Users { get; }

        void Save();
        Task SaveAsync();
    }
}
