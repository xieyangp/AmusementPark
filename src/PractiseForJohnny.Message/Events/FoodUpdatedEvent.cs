using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodUpdatedEvent : IEvent
{
    public FoodUpdatedDto Result { get; set; }
}