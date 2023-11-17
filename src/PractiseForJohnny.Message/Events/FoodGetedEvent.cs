using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodGetedEvent : IEvent
{
    public OutFoodDto Result { get; set; }
}