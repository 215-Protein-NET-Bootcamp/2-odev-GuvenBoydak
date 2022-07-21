namespace BootcampHomeWork.DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
        Task CommitAsync();
    }
}
