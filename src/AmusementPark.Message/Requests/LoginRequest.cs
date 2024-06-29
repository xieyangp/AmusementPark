using AmusementPark.Message.Responses;
using Mediator.Net.Contracts;

namespace AmusementPark.Message.Requests;

public class LoginRequest : IRequest
{
    public string UserName { get; set; }

    public string Password { get; set; }
}

public class LoginResponse : CommonResponse<string>
{
}