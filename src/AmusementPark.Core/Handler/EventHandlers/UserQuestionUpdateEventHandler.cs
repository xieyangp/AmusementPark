using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Events.UserQuestion;

namespace AmusementPark.Core.Handler.EventHandlers;

public class UserQuestionUpdateEventHandler : IEventHandler<UserQuestionUpdateEvent>
{
    public Task Handle(IReceiveContext<UserQuestionUpdateEvent> context, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}