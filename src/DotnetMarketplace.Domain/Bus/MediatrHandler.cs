using DotnetMarketplace.Core.Messages;
using MediatR;

namespace DotnetMarketplace.Core.Bus
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