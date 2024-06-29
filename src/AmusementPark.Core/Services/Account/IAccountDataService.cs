using System.Security.Claims;
using AmusementPark.Core.Domain;
using AmusementPark.Message.DTO.UserAccount;

namespace AmusementPark.Core.Services.Account;

public interface IAccountDataService : IScopedDependency
{
    Task<(bool CanLogin, UserAccountDto Account)> AuthenticateAsync(
        string name, string clearTextPassword, CancellationToken cancellationToken);

    Task<UserAccountDto> GetUserAccountAsync(string name, CancellationToken cancellationToken);
    
    List<Claim> GenerateClaimsFromUserAccount(UserAccountDto account);
}