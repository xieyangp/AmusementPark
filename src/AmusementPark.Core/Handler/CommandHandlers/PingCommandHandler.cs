using AmusementPark.Core.Services;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Commands;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Handler.CommandHandlers;

public class PingCommandHandler : ICommandHandler<PingCommand, PongResponse>
{
    private readonly IPingPongService _pingPongService;

    public PingCommandHandler(IPingPongService pingPongService)
    {
        _pingPongService = pingPongService;
    }

    public async Task<PongResponse> Handle(IReceiveContext<PingCommand> context, CancellationToken cancellationToken)
    {
        var @event = _pingPongService.PingPong(context.Message, cancellationToken);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new PongResponse
        {
            Message = @event.Message
        };
    }
}