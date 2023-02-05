using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public interface IUsersRepository : IRepositoryBase<Users>
    {
        IQueryable<Users> FindByWhere(Expression<Func<Users, bool>> expression);
        Task<Users> AuthenticateUser(UsersLogin usersLogin);
        Task<Users> GetById(long userId);
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> SaveUser(Users users);
        Task<Users> UpdateUser(Users users);
        Task<Users> DeleteUser(Users users);
    }
}
