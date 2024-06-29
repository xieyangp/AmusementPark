using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Events;

public class FoodUpdatedEvent : IEvent
{
    public UpdateFoodDto Result { get; set; }
}