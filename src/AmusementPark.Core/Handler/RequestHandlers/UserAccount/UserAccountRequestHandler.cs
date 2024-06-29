using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Handler.RequestHandlers.UserAccount;

public class UserAccountRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    public Task<LoginResponse> Handle(IReceiveContext<LoginRequest> context, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}