using Mediator.Net.Contracts;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Message.Requests;

public class GetFoodRequest : IRequest
{
    public GetFoodDto Food { get; set; }
}

public class GetFoodResponse : IResponse
{
    public OutFoodDto Result { get; set; }
}