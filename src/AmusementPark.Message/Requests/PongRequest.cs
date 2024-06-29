using Mediator.Net.Contracts;

namespace AmusementPark.Message.Requests;

public class PongResponse : IResponse
{
    public string Message { get; set; }
}