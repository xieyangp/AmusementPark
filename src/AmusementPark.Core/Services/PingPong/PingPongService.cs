using AmusementPark.Message.Commands;
using AmusementPark.Message.Events;

namespace AmusementPark.Core.Services;

public class PingPongService : IPingPongService
{
    public PongEvent PingPong(PingCommand command, CancellationToken cancellationToken)
    {
        return new PongEvent { Message = "pong1" };
    }
}