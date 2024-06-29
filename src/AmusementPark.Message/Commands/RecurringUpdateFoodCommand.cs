using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands;

public class RecurringUpdateFoodCommand : ICommand
{
    public UpdateFoodDto Food { get; set; }
}