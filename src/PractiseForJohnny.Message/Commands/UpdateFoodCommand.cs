using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Message.Commands;

public class UpdateFoodCommand : ICommand
{
    public UpdateFoodDto Food { get; set; }
}

public class UpdateFoodResponse : IResponse
{
    public UpdateFoodDto Result { get; set; }
}