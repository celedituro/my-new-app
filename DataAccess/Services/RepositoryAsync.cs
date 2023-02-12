using Microsoft.EntityFrameworkCore;
using my_new_app.Data;
using my_new_app.DataAccess.Interfaces;

namespace my_new_app.DataAccess.Services
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly PersonContext context;

        public RepositoryAsync(PersonContext context)
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

        public async Task<T> GetById(string id)
        {
            return await EntitySet.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task<T> Delete(string id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
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