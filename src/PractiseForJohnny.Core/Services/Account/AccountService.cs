using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Account;

public partial class AccountService : IAccountService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}