using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands;

public class CreateFoodCommand : ICommand
{
    public CreateFoodDto Food { get; set; }
}

public class CreateFoodResponse : IResponse
{
    public CreateFoodDto Result { get; set; }
}
