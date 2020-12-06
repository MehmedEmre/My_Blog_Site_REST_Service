using Microsoft.EntityFrameworkCore;
using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.DataAccess.Concrete.EntityFramework.Repository
{
    public abstract class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public DbSet<T> context { set; get; }

        public Repository()
        {
            context = db.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            await context.AddAsync(item);
            await db.SaveChangesAsync();

            return item;
        }

        public async Task<T> Get(int id)
        {
            var entity = await context.FindAsync(id);

            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await context.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await context.AsNoTracking().Where(expression).ToListAsync();
        }

        public List<T> GetAllNonGeneric()
        {
            return context.ToList<T>();
        }

        public async Task<bool> Remove(int item)
        {
            var entity = await context.FindAsync(item);

            return await Remove(entity);
        }

        public async Task<bool> Remove(T item)
        {
            context.Remove(item);

            return await  db.SaveChangesAsync() > 0;
        }


        public async Task<T> Update(T item)
        {
            context.Update(item);
            await db.SaveChangesAsync();

            return item;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                db.Dispose();
            }
        }

      
    }
}
