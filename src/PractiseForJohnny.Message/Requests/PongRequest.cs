using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Requests;

public class PongResponse : IResponse
{
    public string Message { get; set; }
}