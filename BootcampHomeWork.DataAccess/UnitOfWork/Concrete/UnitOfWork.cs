using BootcampHomeWork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomeWork.DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly EfHomeworkDbContext _db;
        public bool disposed;

        public UnitOfWork(EfHomeworkDbContext db)
        {
            this._db = db;
        }

        protected virtual void Clean(bool disposing)
        {
            //disposed false ise içerisine girip if içerisinde Dispose komutu ile commitAsync methodu içerisindeki SaveChangesAsync garbage collector tarafındna bellekten kaldırılır.
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
