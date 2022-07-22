using AutoMapper;
using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class EfBaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly IEFRepository<T> _efRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EfBaseService(IEFRepository<T> efRepository, IUnitOfWork unitOfWork)
        {
            _efRepository = efRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetActivesAsync()
        {
            return await _efRepository.GetActivesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _efRepository.GetAllAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _efRepository.GetByIdAsync(id);

        }

        public async Task InsertAsync(T model)
        {
             await _efRepository.InsertAsync(model);
            await _unitOfWork.CommitAsync();

        }

        public async Task RemoveAsync(int id)
        {
            T entity = await _efRepository.GetByIdAsync(id);
             await _efRepository.RemoveAsync(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task UpdateAsync(T model)
        {
            _efRepository.Update(model);
            await _unitOfWork.CommitAsync();
        }
    }
}
