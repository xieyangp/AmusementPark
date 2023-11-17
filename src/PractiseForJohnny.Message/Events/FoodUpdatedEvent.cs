using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodUpdatedEvent : IEvent
{
    public UpdateFoodDto Result { get; set; }
}