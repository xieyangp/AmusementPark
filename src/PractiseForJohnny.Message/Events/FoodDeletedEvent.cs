using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodDeletedEvent : IEvent
{
    public DeleteFoodDto Result { get; set; }
}