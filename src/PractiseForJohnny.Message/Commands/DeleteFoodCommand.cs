using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Commands;

public class DeleteFoodCommand : ICommand
{
    public DeleteFoodDto Food { get; set; }
}

public class DeleteFoodResponse : IResponse
{
    public string Result { get; set; }
}