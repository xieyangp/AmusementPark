using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Services;

public interface IPingPongService : IScopedDependency
{
    PongEvent PingPong(PingCommand command, CancellationToken cancellationToken);
}