using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class UpdateFoodEventHandler : IEventHandler<UpdateFoodEvent>
{
    public Task Handle(IReceiveContext<UpdateFoodEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}