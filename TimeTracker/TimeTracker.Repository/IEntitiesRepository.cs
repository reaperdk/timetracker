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
        IQueryable<T2> GetAnother<T2>(Expression<Func<T2, bool>> predicate) where T2 : class;
        IQueryable<T2> GetAnother<T2, TProperty>(Expression<Func<T2, bool>> predicate, Expression<Func<T2, TProperty>> path) where T2 : class;
        //Task<T> GetAsync(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(int id);
        void Save();
        //Task SaveAsync();
    }
}
