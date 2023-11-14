using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Event;

public class PongEvent : IEvent
{
    public string Message { get; set; }
}