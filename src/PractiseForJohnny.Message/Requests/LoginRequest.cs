using Mediator.Net.Contracts;
using PractiseForJohnny.Message.Responses;

namespace PractiseForJohnny.Message.Requests;

public class LoginRequest : IRequest
{
    public string UserName { get; set; }

    public string Password { get; set; }
}

public class LoginResponse : CommonResponse<string>
{
}