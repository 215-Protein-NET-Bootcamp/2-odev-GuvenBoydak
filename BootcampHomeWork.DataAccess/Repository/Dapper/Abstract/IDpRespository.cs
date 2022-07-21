using BootcampHomework.Entities;

namespace BootcampHomeWork.DataAccess
{
    public interface IDpRespository<T> where T : BaseEntity
    {
        Task InsertAsync(T entity);

        void Remove(T entity);

        Task UpdateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetActivesAsync();
    }
}
