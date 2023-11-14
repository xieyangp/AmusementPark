using ICommand = Mediator.Net.Contracts.ICommand;

namespace PractiseForJohnny.Message.Commands;

public class PingCommand : ICommand
{
    public string Message { get; set; }
}