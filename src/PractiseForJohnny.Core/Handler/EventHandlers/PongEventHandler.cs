using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class PongEventHandler : IEventHandler<PongEvent>
{
    public Task Handle(IReceiveContext<PongEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}