using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class UpdateFoodEventHandler : IEventHandler<FoodUpdatedEvent>
{
    public Task Handle(IReceiveContext<FoodUpdatedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}