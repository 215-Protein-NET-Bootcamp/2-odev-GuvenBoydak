using BootcampHomework.Entities;

namespace BootcampHomeWork.DataAccess
{
    public interface IEmployeeRepository:IEFRepository<Employee>
    {
        Task<List<EmployeeDetailsDto>> GetEmployeeDetails(int id);
    }
}
