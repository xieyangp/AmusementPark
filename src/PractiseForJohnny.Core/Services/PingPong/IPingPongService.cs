using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Event;
using PractiseForJohnny.Message.Request;

namespace PractiseForJohnny.Core.Service;

public interface IPingPongService : IScopedDependency
{
    public Task<PongEvent> PingPong(PingCommand command, CancellationToken cancellationToken);
}