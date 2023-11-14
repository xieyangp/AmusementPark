using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Request;

public class PongResponse : IResponse
{
    public string Message { get; set; }
}