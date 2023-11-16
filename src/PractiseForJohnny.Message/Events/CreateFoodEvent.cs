using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Events;

public class CreateFoodEvent : IEvent
{
    public string Result { get; set; }
}