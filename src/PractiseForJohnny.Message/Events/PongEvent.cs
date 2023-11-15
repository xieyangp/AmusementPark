using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Events;

public class PongEvent : IEvent
{
    public string Message { get; set; }
}