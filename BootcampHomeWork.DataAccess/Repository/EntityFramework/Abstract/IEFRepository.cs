using BootcampHomework.Entities;
using System.Linq.Expressions;

namespace BootcampHomeWork.DataAccess
{
    public interface IEFRepository<T> where T : BaseEntity
    {
        Task<bool> InsertAsync(T entity);

        Task<bool> RemoveAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetActivesAsync();

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression);
    }
}
