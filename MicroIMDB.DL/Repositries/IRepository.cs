

using System.Linq.Expressions;

namespace MicroIMDb.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> match);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task SaveChangesAsync();
    }


}
