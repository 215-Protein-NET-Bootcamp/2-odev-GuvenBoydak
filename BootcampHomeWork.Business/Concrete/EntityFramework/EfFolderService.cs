using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class EfFolderService : EfBaseService<Folder>, IFolderService
    {
        public EfFolderService(IEFRepository<Folder> efRepository, IUnitOfWork unitOfWork) : base(efRepository, unitOfWork)
        {
        }
    }
}
