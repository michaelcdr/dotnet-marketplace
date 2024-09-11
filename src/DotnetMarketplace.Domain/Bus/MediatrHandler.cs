using MediatR;
using MKT.Core.Messages;

namespace MKT.Core.Bus
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediatr;
        public MediatrHandler(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task PublishEvent<T>(T targetEvent) where T : Event
        {
            await _mediatr.Publish(targetEvent);
        }
    }
}