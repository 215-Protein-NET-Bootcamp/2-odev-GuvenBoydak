using BootcampHomework.Entities;
using Dapper;
using System.Data;
using System.Linq.Expressions;

namespace BootcampHomeWork.DataAccess
{
    public class DPCountryRepository : ICountryRepository
    {
        private readonly DapperHomeworkDbContext _db;

        public DPCountryRepository(DapperHomeworkDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Country>> GetActivesAsync()
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryAsync<Country>("select * from \"Countries\" where  \"Status\" != '2'");
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryAsync<Country>("select * from  \"Countries\"");
            }
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                return await con.QueryFirstOrDefaultAsync<Country>("select * from  \"Countries\" where \"Id\"=@id", new { id = id });
            }
        }

        public async Task InsertAsync(Country entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                await con.ExecuteAsync("insert into  \"Countries\" ( \"CountryName\", \"Continent\", \"Currency\",\"CreatedDate\",\"Status\") VALUES (@countryname,@continent,@currency,@createddate,@status)",
                    new
                    {
                        countryname = entity.CountryName,
                        continent = entity.Continent,
                        currency = entity.Currency,
                        createddate = entity.CreatedDate,
                        status = entity.Status
                    });
            }
        }

        public async void Remove(Country entity)
        {

            Country deletedCountry = await GetByIdAsync(entity.Id);
            deletedCountry.DeletedDate = DateTime.Now;
            deletedCountry.Status = DataStatus.deleted;
           await UpdateAsync(deletedCountry);

        }

        public async Task UpdateAsync(Country entity)
        {
            using (IDbConnection con = _db.CreateConnection())
            {
                //DeletedDate null degilse bir silme işleminin update edildigi anlayıp status'u deleted yapıp pasif delete yapıyoruz.
                if (entity.DeletedDate != null)
                {
                    con.Execute("update  \"Countries\" set \"CountryName\"=@countryName,\"Continent\"=@continent,\"Currency\"=@currency,\"DeletedDate\"=@deleteddate,\"Status\"=@status where \"Id\"=@id", new
                    {
                        id=entity.Id,
                        countryname = entity.CountryName,
                        continent = entity.Continent,
                        currency = entity.Currency,
                        deleteddate = entity.DeletedDate,
                        status = entity.Status
                    });
                }
                else //DeletedDate boş ise bir update işlemi olucagı için updateddate'ini verip status'u update e çekiyoruz.
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.Status = DataStatus.updated;

                    Country updateCountry = await GetByIdAsync(entity.Id);

                    entity.CountryName = updateCountry.CountryName != default ? entity.CountryName : updateCountry.CountryName;
                    entity.Continent = updateCountry.Continent != default ? entity.Continent : updateCountry.Continent;
                    entity.Currency = updateCountry.Currency != default ? entity.Currency : updateCountry.Currency;
                    entity.UpdatedDate = updateCountry.UpdatedDate != default ? entity.UpdatedDate : updateCountry.UpdatedDate;

                    con.Execute("update  \"Countries\" set \"CountryName\"=@countryName,\"Continent\"=@continent,\"Currency\"=@currency,\"UpdatedDate\"=@updateddate,\"Status\"=@status where \"Id\"=@id", new
                    {
                        id=entity.Id,
                        countryname = entity.CountryName,
                        continent = entity.Continent,
                        currency = entity.Currency,
                        updateddate = entity.UpdatedDate,
                        status = entity.Status
                    });
                }
            }
        }
    }
}
