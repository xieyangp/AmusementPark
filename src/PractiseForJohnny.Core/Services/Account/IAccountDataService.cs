using System.Security.Claims;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO.UserAccount;

namespace PractiseForJohnny.Core.Services.Account;

public interface IAccountDataService : IScopedDependency
{
    Task<(bool CanLogin, UserAccountDto Account)> AuthenticateAsync(
        string name, string clearTextPassword, CancellationToken cancellationToken);

    Task<UserAccountDto> GetUserAccountAsync(string name, CancellationToken cancellationToken);
    
    List<Claim> GenerateClaimsFromUserAccount(UserAccountDto account);
}