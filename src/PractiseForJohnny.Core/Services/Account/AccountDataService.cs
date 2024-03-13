using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Core.Extension;
using PractiseForJohnny.Message.DTO.UserAccount;

namespace PractiseForJohnny.Core.Services.Account;

public class AccountDataService : IAccountDataService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public AccountDataService(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<(bool, UserAccountDto)> AuthenticateAsync(
        string name, string clearTextPassword, CancellationToken cancellationToken)
    {
        var hashPassword = clearTextPassword.ToSha256();

        var canLogin = await _repository
            .AnyAsync<UserAccount>(x => x.UserName == name && x.PassWord == hashPassword, cancellationToken)
            .ConfigureAwait(false);

        if (!canLogin)
            return (false, null);

        var account = await GetUserAccountAsync(name, cancellationToken).ConfigureAwait(false);

        return (true, account);
    }

    public async Task<UserAccountDto> GetUserAccountAsync(string name, CancellationToken cancellationToken)
    {
        var query = _repository.QueryNoTracking<UserAccount>();

        if (name.IsNullOrEmpty())
            query = query.Where(x => x.UserName == name);

        return await query.ProjectTo<UserAccountDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
    }

    public List<Claim> GenerateClaimsFromUserAccount(UserAccountDto account)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, account.UserName),
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Authentication, "Self")
        };
        claims.AddRange(account.Roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));
        return claims;
    }
}