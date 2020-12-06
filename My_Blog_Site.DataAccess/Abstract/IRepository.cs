using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.DataAccess.Abstract
{
    public interface IRepository<T>:IDisposable
    {
        Task<T> Add(T item);

        Task<T> Get(int id);

        Task<List<T>> GetAll();

        List<T> GetAllNonGeneric();

        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);

        Task<T> Update(T item);

        Task<bool> Remove(T item);

        Task<bool> Remove(int item);

        
    }
}
