using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class EfEmployeeService : EfBaseService<Employee>, IEmployeeService
    {
        public EfEmployeeService(IEFRepository<Employee> efRepository, IUnitOfWork unitOfWork) : base(efRepository, unitOfWork)
        {
        }
    }
}
