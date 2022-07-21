using BootcampHomework.Entities;

namespace BootcampHomeWork.Business
{
    public interface IBaseService<T>
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetActivesAsync();

        Task InsertAsync(T model);

        Task UpdateAsync(T model);

        Task RemoveAsync(int id);
    }
}
