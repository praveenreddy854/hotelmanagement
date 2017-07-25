using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public abstract class GenericRepository<T> : IDisposable, IRepository<T> where T : class
    {
        
        private readonly HotelDbContext _hotelDbContext;
        private readonly IDbSet<T> _dbSet;
        
        public GenericRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
            _dbSet = hotelDbContext.Set<T>();
        }

        public T Create(T obj)
        {
            _dbSet.Add(obj);
            _hotelDbContext.SaveChanges();
            return obj;
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);

            _hotelDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _hotelDbContext.Dispose();
            
        }

        public virtual IEnumerable<T> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T Get(int? id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T,bool>> @where)
        {
            return _dbSet.Where(where).ToList();
        }
        public void Put(T obj)
        {
            
            _dbSet.Attach(obj);
            _hotelDbContext.SaveChanges();
        }
    }
}
