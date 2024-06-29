using ICommand = Mediator.Net.Contracts.ICommand;

namespace AmusementPark.Message.Commands;

public class PingCommand : ICommand
{
    public string Message { get; set; }
}