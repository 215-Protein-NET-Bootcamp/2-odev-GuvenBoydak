using BootcampHomework.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomeWork.DataAccess.Repository.Dapper.Concrete
{
    public class DPFolderRepository : IDpRespository<Folder>
    {

        private readonly DapperHomeworkDbContext _db;

        public DPFolderRepository(DapperHomeworkDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Folder>> GetActivesAsync()
        {
            using (IDbConnection con=_db.CreateConnection())
            {
                return await con.QueryAsync<Folder>("select * from folders where status != '2' ");
            }
        }

        public async Task<IEnumerable<Folder>> GetAllAsync()
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryAsync<Folder>("select * from folders");
            }
        }

        public async Task<Folder> GetByIdAsync(int id)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryFirstOrDefaultAsync<Folder>("select * from folders where id=@id", new { id = id });
            }
        }

        public async Task InsertAsync(Folder entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                await con.ExecuteAsync("insert into folders (accesstype, employeeid,createddate, status) VALUES @accesstype,@employeeid,@createddate,@status",
                    new
                    {
                        accesstype = entity.AccessType,
                        createddate = entity.CreatedDate,
                        status = entity.Status,
                        employeeid = entity.EmployeeId,
                    });
            }
        }

        public async void Remove(Folder entity)
        {
            Folder deletedFolder = await GetByIdAsync(entity.Id);
            deletedFolder.DeletedDate = DateTime.Now;
            deletedFolder.Status = entity.Status;
            await UpdateAsync(deletedFolder);
        }

        public async Task UpdateAsync(Folder entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                //DeletedDate null degilse bir silme işleminin update edildigi anlayıp status'u deleted yapıp pasif delete yapıyoruz.
                if (entity.DeletedDate!=null)
                {
                    con.Execute("update folders set @accesstype,@employeeid,@deleteddate,@status", new
                    {
                        accesstype=entity.AccessType,
                        employeeid=entity.EmployeeId,
                        deleteddate = entity.DeletedDate,
                        status = entity.Status
                    });
                }
                else
                {
                    entity.UpdatedDate= DateTime.Now;
                    entity.Status = DataStatus.updated;

                    Folder updatedFolder = await GetByIdAsync(entity.Id);

                    entity.AccessType = updatedFolder.AccessType != default ? entity.AccessType : updatedFolder.AccessType;
                    entity.EmployeeId = updatedFolder.EmployeeId != default ? entity.EmployeeId : updatedFolder.EmployeeId;
                    entity.UpdatedDate = updatedFolder.UpdatedDate != default ? entity.UpdatedDate : updatedFolder.UpdatedDate;


                    //DeletedDate boş ise bir update işlemi olucagı için updateddate'ini verip status'u update e çekiyoruz.
                    con.Execute("update folders set @accesstype,@employeeid,@updateddate,@status", new
                    {
                        accesstype = entity.AccessType,
                        employeeid = entity.EmployeeId,
                        updateddate = entity.UpdatedDate,
                        status = entity.Status
                    });
                }
            }
        }
    }
}
