using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Commands;

public class CreateFoodCommand : ICommand
{
    public CreateFoodDto Food { get; set; }
}

public class CreateFoodResponse : IResponse
{
    public string Result { get; set; }
}
