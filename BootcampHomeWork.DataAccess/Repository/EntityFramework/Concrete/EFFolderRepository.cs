using BootcampHomework.Entities;

namespace BootcampHomeWork.DataAccess
{
    public class EFFolderRepository : EFBaseRepository<Folder>, IFolderRepository
    {
        public EFFolderRepository(EfHomeworkDbContext db) : base(db)
        {
        }
    }
}
