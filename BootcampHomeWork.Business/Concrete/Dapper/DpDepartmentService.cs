using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class DpDepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DpDepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetActivesAsync()
        {
           return await _departmentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetActivesAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Department model)
        {
            await _departmentRepository.InsertAsync(model);
        }

        public async Task RemoveAsync(int id)
        {
            Department department = await _departmentRepository.GetByIdAsync(id);
            _departmentRepository.Remove(department);
        }

        public async Task UpdateAsync(Department model)
        {
            await _departmentRepository.UpdateAsync(model);
        }
    }
}
