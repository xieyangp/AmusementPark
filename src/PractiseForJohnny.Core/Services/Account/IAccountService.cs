using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Account;

public partial interface IAccountService : IScopedDependency
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
}

