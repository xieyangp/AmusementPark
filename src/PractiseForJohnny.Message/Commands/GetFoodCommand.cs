using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Commands;

public class GetFoodCommand : ICommand
{
    public GetFoodDto Food { get; set; }
}

public class GetFoodResponse : IResponse
{
    public OutFoodDto Result { get; set; }
}