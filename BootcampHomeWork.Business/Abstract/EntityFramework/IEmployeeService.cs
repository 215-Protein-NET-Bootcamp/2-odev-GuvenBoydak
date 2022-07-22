using BootcampHomework.Entities;

namespace BootcampHomeWork.Business
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        Task<List<EmployeeDetailsDto>> GetEmployeeDetails(int id);

    }
}
