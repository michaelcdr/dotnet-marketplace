using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
