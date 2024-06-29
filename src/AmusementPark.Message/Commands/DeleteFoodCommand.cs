using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Commands;

public class DeleteFoodCommand : ICommand
{
    public DeleteFoodDto Food { get; set; }
}

public class DeleteFoodResponse : IResponse
{
    public DeleteFoodDto Result { get; set; }
}