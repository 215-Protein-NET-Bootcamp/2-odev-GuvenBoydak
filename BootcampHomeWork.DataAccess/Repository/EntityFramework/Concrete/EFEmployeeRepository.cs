using BootcampHomework.Entities;

namespace BootcampHomeWork.DataAccess
{
    public class EFEmployeeRepository : EFBaseRepository<Employee>, IEmployeeRepository
    {
        public EFEmployeeRepository(EfHomeworkDbContext db) : base(db)
        {
        }
    }
}
