using Mediator.Net.Contracts;

namespace AmusementPark.Message.Events;

public class PongEvent : IEvent
{
    public string Message { get; set; }
}