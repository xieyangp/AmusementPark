using System.Net;
using Mediator.Net.Contracts;

namespace PractiseForJohnny.Message.Responses;

public class CommonResponse<T> : CommonResponse
{
    public T Data { get; set; }
}

public class CommonResponse : IResponse
{
    public HttpStatusCode Code { get; set; }

    public string Msg { get; set; }
}