using BootcampHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampHomeWork.DataAccess
{
    public class EFEmployeeRepository : EFBaseRepository<Employee>, IEmployeeRepository
    {
        public EFEmployeeRepository(EfHomeworkDbContext db) : base(db)
        {
        }

        public async Task<List<EmployeeDetailsDto>> GetEmployeeDetails(int id)
        {
            IQueryable<EmployeeDetailsDto> employeeDetailsDto = from e in _db.Employees
                                                                join f in _db.Folders
                                                                on e.Id equals f.EmployeeId
                                                                join d in _db.Departments
                                                                on e.DepartmentId equals d.Id
                                                                join c in _db.Countries
                                                                on d.CountryId equals c.Id
                                                                where c.Id == id
                                                                select new EmployeeDetailsDto
                                                                {
                                                                    
                                                                    DepartmentId = d.Id,
                                                                    DepartmentName = d.DepartmentName,
                                                                    EmployeeId = id,
                                                                    EmployeeName = e.EmployeeName,
                                                                    CountryId = c.Id,
                                                                    CountryName = c.CountryName,
                                                                    Continent = c.Continent,
                                                                    Currency = c.Currency,
                                                                    FolderId = f.Id,
                                                                    AccessType = f.AccessType
                                                                };
            return await employeeDetailsDto.ToListAsync();
        }
    }
}
