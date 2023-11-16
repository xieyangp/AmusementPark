using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Events;

public class GetFoodEvent : IEvent
{
    public OutFoodDto Result { get; set; }
}