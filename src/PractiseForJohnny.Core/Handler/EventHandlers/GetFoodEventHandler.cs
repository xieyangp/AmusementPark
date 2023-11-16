using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class GetFoodEventHandler : IEventHandler<GetFoodEvent>
{
    public Task Handle(IReceiveContext<GetFoodEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}