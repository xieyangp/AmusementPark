using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class FoodDeletedEvent : IEvent
{
    public FoodDeletedDto Result { get; set; }
}