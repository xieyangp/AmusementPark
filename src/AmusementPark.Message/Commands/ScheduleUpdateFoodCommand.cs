using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands;

public class ScheduleUpdateFoodCommand : ICommand
{
    public UpdateFoodDto Food { get; set; }
}