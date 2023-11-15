using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Services;

public class PingPongService : IPingPongService
{
    public PongEvent PingPong(PingCommand command, CancellationToken cancellationToken)
    {
        return new PongEvent { Message = "pong1" };
    }
}