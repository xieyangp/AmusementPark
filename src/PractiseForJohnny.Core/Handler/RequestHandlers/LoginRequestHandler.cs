using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Account;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Handler.RequestHandlers;

public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IAccountService _accountService;

    public LoginRequestHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<LoginResponse> Handle(IReceiveContext<LoginRequest> context, CancellationToken cancellationToken)
    {
        return await _accountService.LoginAsync(context.Message, cancellationToken).ConfigureAwait(false);
    }
}