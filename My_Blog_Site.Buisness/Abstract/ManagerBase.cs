using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.Buisness.Abstract
{
    public abstract class ManagerBase<T> : IRepositoryService<T> where T : class
    {

        private readonly IRepository<T> _IRepository;

        protected ManagerBase(IRepository<T> IRepository)
        {
            _IRepository = IRepository;
        }

        public async Task<T> Add(T item)
        {
            return await _IRepository.Add(item);
        }

        public async Task<T> Get(int id)
        {
            return await _IRepository.Get(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _IRepository.GetAll();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
           return await _IRepository.GetAll(expression);
        }

        public async Task<bool> Remove(T item)
        {
            return await _IRepository.Remove(item);
        }

        public async Task<bool> Remove(int item)
        {
            return await _IRepository.Remove(item);
        }

        public async Task<T> Update(T item)
        {
            return await _IRepository.Update(item);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _IRepository.Dispose();
            }
        }

        public List<T> GetAllNonGeneric()
        {
            return _IRepository.GetAllNonGeneric();
        }
    }
}
