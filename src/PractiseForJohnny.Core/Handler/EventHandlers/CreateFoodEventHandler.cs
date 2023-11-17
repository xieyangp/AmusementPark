using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class CreateFoodEventHandler : IEventHandler<FoodCreatedEvent>
{
    public Task Handle(IReceiveContext<FoodCreatedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}