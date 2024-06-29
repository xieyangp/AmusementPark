using AmusementPark.Message.Commands;
using AmusementPark.Message.Events;

namespace AmusementPark.Core.Services;

public interface IPingPongService : IScopedDependency
{
    PongEvent PingPong(PingCommand command, CancellationToken cancellationToken);
}