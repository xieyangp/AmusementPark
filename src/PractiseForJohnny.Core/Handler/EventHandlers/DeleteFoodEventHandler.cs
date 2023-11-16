using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class DeleteFoodEventHandler : IEventHandler<DeleteFoodEvent>
{
    public Task Handle(IReceiveContext<DeleteFoodEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}