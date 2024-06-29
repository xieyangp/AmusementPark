using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Events;

public class FoodDeletedEvent : IEvent
{
    public DeleteFoodDto Result { get; set; }
}