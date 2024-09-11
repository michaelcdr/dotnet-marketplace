using MKT.Core.Messages;

namespace MKT.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T targetEvent) where T : Event;
    }
}
