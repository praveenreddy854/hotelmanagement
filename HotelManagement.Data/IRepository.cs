using HotelManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public interface IRepository<T> where T : class
    {
        T Create(T obj);
        void Put(T obj);
        void Delete(T obj);
        IEnumerable<T> Get();
         IEnumerable<T> Get(Expression<Func<T,bool>> @where);
        T Get(int? id);
         
    }
}
