using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Events;

public class DeleteFoodEvent : IEvent
{
    public string Result { get; set; }
}