using System.Linq.Expressions;

namespace Data.Repositories.IRepositories;

public interface IRepository<T> where T : class
{
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsyncById(int id);
}