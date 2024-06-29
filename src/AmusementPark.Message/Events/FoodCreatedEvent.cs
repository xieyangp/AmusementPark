using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Events;

public class FoodCreatedEvent : IEvent
{
    public CreateFoodDto Result { get; set; }
}