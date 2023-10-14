namespace DotnetMarketplace.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
