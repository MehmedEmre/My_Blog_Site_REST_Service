using My_Blog_Site.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<List<Article>> GetAllArticleModel();

        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);

        IQueryable<Article> GetAllArticleModelQuery();

        Task<T> Update(T item);

        Task<bool> Remove(T item);

        Task<bool> Remove(int item);
    }
}
