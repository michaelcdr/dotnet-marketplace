using DotnetMarketplace.Core.Messages;

namespace DotnetMarketplace.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T targetEvent) where T : Event;
    }
}
