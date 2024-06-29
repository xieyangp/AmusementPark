using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Events;

namespace AmusementPark.Core.Handler.EventHandlers;

public class CreateFoodEventHandler : IEventHandler<FoodCreatedEvent>
{
    public Task Handle(IReceiveContext<FoodCreatedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}