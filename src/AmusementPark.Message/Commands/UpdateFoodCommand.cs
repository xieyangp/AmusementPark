using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;
using AmusementPark.Message.Events;

namespace AmusementPark.Message.Commands;

public class UpdateFoodCommand : ICommand
{
    public UpdateFoodDto Food { get; set; }
}

public class UpdateFoodResponse : IResponse
{
    public UpdateFoodDto Result { get; set; }
}