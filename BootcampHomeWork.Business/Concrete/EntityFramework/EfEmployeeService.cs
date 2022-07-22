using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class EfEmployeeService : EfBaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EfEmployeeService(IEFRepository<Employee> efRepository, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository) : base(efRepository, unitOfWork)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDetailsDto>> GetEmployeeDetails(int id)
        {
           return await _employeeRepository.GetEmployeeDetails(id);
        }
    }
}
