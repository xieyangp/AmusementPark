using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class GetFoodEventHandler : IEventHandler<FoodGetedEvent>
{
    public Task Handle(IReceiveContext<FoodGetedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}