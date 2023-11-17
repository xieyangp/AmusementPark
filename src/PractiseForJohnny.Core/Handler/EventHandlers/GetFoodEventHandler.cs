using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class GetFoodEventHandler : IEventHandler<FoodGetEvent>
{
    public Task Handle(IReceiveContext<FoodGetEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}