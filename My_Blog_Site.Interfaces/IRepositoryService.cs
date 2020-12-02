using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.Interfaces
{
    public interface IRepositoryService<T>:IDisposable
    {
        Task<T> Add(T item);

        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);

        Task<T> Update(T item);

        Task<bool> Remove(T item);

        Task<bool> Remove(int item);


    }
}
