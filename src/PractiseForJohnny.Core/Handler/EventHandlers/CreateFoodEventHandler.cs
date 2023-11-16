using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Handler.EventHandlers;

public class CreateFoodEventHandler : IEventHandler<CreateFoodEvent>
{
    public Task Handle(IReceiveContext<CreateFoodEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}