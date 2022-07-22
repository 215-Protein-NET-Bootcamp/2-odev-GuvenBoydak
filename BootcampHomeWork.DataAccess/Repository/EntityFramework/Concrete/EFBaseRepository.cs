using BootcampHomework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BootcampHomeWork.DataAccess
{
    public class EFBaseRepository<T> : IEFRepository<T> where T : BaseEntity, new() //Tüm Entitylerimiz BaseEntity den kalıtım aldıgı için BaseEntity ve New() newlenebilir olması kısıtlıyıcısı koyduk.
    {
        protected readonly EfHomeworkDbContext _db;
        private readonly DbSet<T> _entities;

        public EFBaseRepository(EfHomeworkDbContext db)
        {
            _db = db;
            _entities = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetActivesAsync()
        {
            return await _entities.Where(x => x.Status != DataStatus.deleted).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            if (entity != null)
            {
                await _entities.AddAsync(entity);
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            T deletedEntity = await GetByIdAsync(entity.Id);
            if (deletedEntity != null)
            {
                deletedEntity.DeletedDate = DateTime.UtcNow;
                deletedEntity.Status = DataStatus.deleted;
                return true;
            }
            return false;
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.Status = DataStatus.updated;
            _entities.Update(entity);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}
