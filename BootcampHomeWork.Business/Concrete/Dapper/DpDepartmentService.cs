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
            try
            {
                await _departmentRepository.InsertAsync(model);
            }
            catch (Exception)
            {

                throw new Exception($"Saving_Error {typeof(Country).Name}");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Department department = await _departmentRepository.GetByIdAsync(id);
                _departmentRepository.Remove(department);
            }
            catch (Exception)
            {

                throw new Exception($"Delete_Error {typeof(Country).Name}");
            }
        }

        public async Task UpdateAsync(Department model)
        {
            try
            {
                await _departmentRepository.UpdateAsync(model);
            }
            catch (Exception)
            {

                throw new Exception($"Update_Error {typeof(Country).Name}");
            }
        }
    }
}
