using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Services.Account;

public partial interface IAccountService : IScopedDependency
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
}

