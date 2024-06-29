using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands;

public class DelayCreateFoodCommand : ICommand
{
    public CreateFoodDto Food { get; set; }
}