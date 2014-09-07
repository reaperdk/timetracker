using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TimeTracker.Repository
{
    public interface IEntitiesRepository<T> : IDisposable where T : class
    {
        T Get(int id);
        IQueryable<T> Get();
        IQueryable<T> Get<TProperty>(Expression<Func<T, TProperty>> path);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get<TProperty>(Expression<Func<T, bool>> predicate, Expression<Func<T, TProperty>> path);
        //Task<T> GetAsync(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(int id);
        void Save();
        //Task SaveAsync();
    }
}
