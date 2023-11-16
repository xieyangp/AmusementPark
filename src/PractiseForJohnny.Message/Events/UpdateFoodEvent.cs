using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Events;

public class UpdateFoodEvent : IEvent
{
    public string Result { get; set; }
}