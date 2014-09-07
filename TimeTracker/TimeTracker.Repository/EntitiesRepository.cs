using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.Repository
{
    public class EntitiesRepository<T> : IEntitiesRepository<T> where T : class
    {
        readonly EntitiesContext _context;

        bool _disposed;

        public EntitiesRepository()
        {
            _context = new EntitiesContext();
            _disposed = false;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get<TProperty>(Expression<Func<T, TProperty>> path)
        {
            return _context.Set<T>().Include(path);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> Get<TProperty>(Expression<Func<T, bool>> predicate, Expression<Func<T, TProperty>> path)
        {
            return _context.Set<T>().Where(predicate).Include(path);
        }

        public IQueryable<T2> GetAnother<T2>(Expression<Func<T2, bool>> predicate) where T2 : class
        {
            return _context.Set<T2>().Where(predicate);
        }

        public IQueryable<T2> GetAnother<T2, TProperty>(Expression<Func<T2, bool>> predicate, Expression<Func<T2, TProperty>> path) where T2 : class
        {
            return _context.Set<T2>().Where(predicate).Include(path);
        }

        //public async Task<T> GetAsync(int id)
        //{
        //    return await _context.Set<T>().FindAsync(id);
        //}

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //public async Task SaveAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
