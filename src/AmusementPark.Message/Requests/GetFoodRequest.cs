using AmusementPark.Message.DTO;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Requests;

public class GetFoodRequest : IRequest
{
    public GetFoodDto Food { get; set; }
}

public class GetFoodResponse : IResponse
{
    public OutFoodDto Result { get; set; }
}