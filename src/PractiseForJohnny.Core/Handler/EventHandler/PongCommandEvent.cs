using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Event;

namespace PractiseForJohnny.Core.Handler.EventHandler;

public class PongEventHandler : IEventHandler<PongEvent>
{
    public async Task Handle(IReceiveContext<PongEvent> context, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}