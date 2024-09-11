namespace MKT.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
