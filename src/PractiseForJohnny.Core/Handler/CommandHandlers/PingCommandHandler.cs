using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class PingCommandHandler : ICommandHandler<PingCommand, PongResponse>
{
    private readonly IPingPongService _pingPongService;

    public PingCommandHandler(IPingPongService pingPongService)
    {
        _pingPongService = pingPongService;
    }

    public Task<PongResponse> Handle(IReceiveContext<PingCommand> context, CancellationToken cancellationToken)
    {
        var @event = _pingPongService.PingPong(context.Message, cancellationToken);

        context.PublishAsync(@event).ConfigureAwait(false);

        return Task.Run(() =>
        {
            var response = new PongResponse();
            response.Message = @event.Message;

            return response;
        });
    }
}