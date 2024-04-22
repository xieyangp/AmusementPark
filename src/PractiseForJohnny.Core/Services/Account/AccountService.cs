using System.Net;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Account;

public class AccountService : IAccountService
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IAccountDataService _accountDataService;

    public AccountService(ITokenProvider tokenProvider, IAccountDataService accountDataService)
    {
        _accountDataService = accountDataService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var (canLogin, account) = await _accountDataService
            .AuthenticateAsync(request.UserName, request.Password, cancellationToken).ConfigureAwait(false);

        if (!canLogin)
            return new LoginResponse { Code = HttpStatusCode.Unauthorized };

        return new LoginResponse
        {
            Data = _tokenProvider.Genrate(_accountDataService.GenerateClaimsFromUserAccount(account))
        };
    }
}