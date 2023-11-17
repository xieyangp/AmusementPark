using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodCreatedEvent : IEvent
{
    public FoodCreatedDto Result { get; set; }
}