using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodGetEvent : IEvent
{
    public OutFoodDto Result { get; set; }
}