using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Events;

namespace AmusementPark.Core.Handler.EventHandlers;

public class UpdateFoodEventHandler : IEventHandler<FoodUpdatedEvent>
{
    public Task Handle(IReceiveContext<FoodUpdatedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}