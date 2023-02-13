using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using my_new_app.Data;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.DataAccess.Services
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PersonContext context;

        public RepositoryBase(PersonContext context)
        {
            this.context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return context.Set<T>();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {   
            return await EntitySet.FindAsync(id); 
        }
        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task<T?> Delete(int id)
        {
            T? entity = await EntitySet.FindAsync(id);
            if(entity is not null)
            {
                EntitySet.Remove(entity);
                await Save();
                return entity;
            }
            return null;
        }

        public async Task Update(T entity)
        {
           context.Entry(entity).State = EntityState.Modified;
           await Save();
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}