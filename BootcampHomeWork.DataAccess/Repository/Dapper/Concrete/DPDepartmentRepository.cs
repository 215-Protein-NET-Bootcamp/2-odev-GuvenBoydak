using BootcampHomework.Entities;
using Dapper;
using System.Data;

namespace BootcampHomeWork.DataAccess
{
    public class DPDepartmentRepository : IDepartmentRepository
    {

        private readonly DapperHomeworkDbContext _db;

        public DPDepartmentRepository(DapperHomeworkDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Department>> GetActivesAsync()
        {
            using (IDbConnection con=_db.CreateConnection())
            {
                return await con.QueryAsync<Department>("select * from departments where status != '2' ");
            }
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryAsync<Department>("select * from departments");
            }
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryFirstOrDefaultAsync<Department>("select * from departments where id=@id", new { id = id });
            }
        }

        public async Task InsertAsync(Department entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                await con.ExecuteAsync("insert into departments (departmentname, countryid,createddate, status) VALUES (@departmentname,@countryid,@createddate,@status)",
                    new
                    {
                        departmentname = entity.DepartmentName,
                        createddate = entity.CreatedDate,
                        status = entity.Status,
                        countryid = entity.CountryId,
                    });
            }
        }

        public async void Remove(Department entity)
        {
            Department deletedDepartment = await GetByIdAsync(entity.Id);
            deletedDepartment.DeletedDate = DateTime.Now;
            deletedDepartment.Status = entity.Status;
            await UpdateAsync(deletedDepartment);
        }

        public async Task UpdateAsync(Department entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                //DeletedDate null degilse bir silme işleminin update edildigi anlayıp status'u deleted yapıp pasif delete yapıyoruz.
                if (entity.DeletedDate!=null)
                {
                    con.Execute("update departments set departmentname=@departmentname,countryid=@countryid,deleteddate=@deleteddate,status=@status  where id=@id", new
                    {
                        id=entity.Id,
                        departmentname = entity.DepartmentName,
                        countryid = entity.CountryId,
                        deleteddate = entity.DeletedDate,
                        status = entity.Status
                    });
                }
                else
                {
                    entity.UpdatedDate= DateTime.Now;
                    entity.Status = DataStatus.updated;

                    Department updatedDepartment = await GetByIdAsync(entity.Id);

                    entity.DepartmentName = updatedDepartment.DepartmentName != default ? entity.DepartmentName : updatedDepartment.DepartmentName;
                    entity.CountryId = updatedDepartment.CountryId != default ? entity.CountryId : updatedDepartment.CountryId;


                    //DeletedDate boş ise bir update işlemi olucagı için updateddate'ini verip status'u update e çekiyoruz.
                    con.Execute("update departments set departmentname=@departmentname,countryid=@countryid,updateddate=@updateddate,status=@status  where id=@id", new
                    {
                        id=entity.Id,
                        departmentname = entity.DepartmentName,
                        countryid = entity.CountryId,
                        updateddate = entity.UpdatedDate,
                        status = entity.Status
                    });
                }
            }
        }
    }
}
