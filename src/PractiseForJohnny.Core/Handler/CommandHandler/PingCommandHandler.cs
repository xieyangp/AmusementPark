using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Service;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Request;

namespace PractiseForJohnny.Core.Handler.CommandHandler;

public class PingCommandHandler : ICommandHandler<PingCommand,PongResponse>
{
    private readonly IPingPongService _pingPongService;

    public PingCommandHandler(IPingPongService pingPongService)
    {
        _pingPongService = pingPongService;
    }

    public async Task<PongResponse> Handle(IReceiveContext<PingCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _pingPongService.PingPong(context.Message, cancellationToken).ConfigureAwait(false);
        
        await context.PublishAsync(@event).ConfigureAwait(false);
        
        return new PongResponse
        {
            Message = @event.Message
        };
    }
}