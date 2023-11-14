using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Event;
using PractiseForJohnny.Message.Request;

namespace PractiseForJohnny.Core.Service;

public class PingPongService : IPingPongService
{
    public async Task<PongEvent> PingPong(PingCommand command, CancellationToken cancellationToken)
    {
        return new PongEvent() { Message = "pong1" };
    }
}