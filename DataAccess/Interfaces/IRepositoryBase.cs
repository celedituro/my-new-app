using System.Linq.Expressions;
namespace my_new_app.DataAccess.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Insert(T entity);
        Task<T> Delete(string id);
        Task Update(T entity);
    }
}