using CrystalFlights.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrystalFlights.BO.BaseRepository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CFContext _cfContext { get; set; }

        public RepositoryBase(CFContext cfContext)
        {
            this._cfContext = cfContext;
        }

        public IQueryable<T> FindAll()
        {
            return _cfContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _cfContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _cfContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _cfContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _cfContext.Set<T>().Remove(entity);
        }
    }
}
