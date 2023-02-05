using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrystalFlights.BO
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        public UsersRepository(CFContext cfContext) : base(cfContext) { }

        public IQueryable<Users> FindByWhere(Expression<Func<Users, bool>> expression)
        {
            return _cfContext.Set<Users>().Where(expression);
        }

        public async Task<Users> AuthenticateUser(UsersLogin usersLogin)
        {
            return FindByWhere(u => u.Email == usersLogin.UserName && u.Password == usersLogin.Password).FirstOrDefault();
        }

        public async Task<Users> GetById(long userId)
        {
            return FindByWhere(u => u.UserId == userId).FirstOrDefault();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await FindAll()
                            .Where(ow => ow.IsActive)
                            .OrderBy(ow => ow.UserName)
                            .ToListAsync();
        }

        public async Task<Users> SaveUser(Users users)
        {
            await Task.Run(() => Create(users));
            _cfContext.SaveChanges();

            return users;
        }

        public async Task<Users> UpdateUser(Users users)
        {
            await Task.Run(() => Update(users));
            _cfContext.SaveChanges();

            return users;
        }

        public async Task<Users> DeleteUser(Users users)
        {
            users.IsActive = false;

            await Task.Run(() => Update(users));
            _cfContext.SaveChanges();

            return users;
        }
    }
}
