using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class DeleteFoodEventHandler : IEventHandler<FoodDeletedEvent>
{
    public Task Handle(IReceiveContext<FoodDeletedEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}