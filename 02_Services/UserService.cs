using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace Services;

public class UserService : IUserService
{
    readonly UsersDbRepo _repo = null;
    readonly ILogger<UserService> _logger = null;

    public async Task<ResponseListDto<UserDbm>> ReadAsync(
        int page,
        int pageSize,
        bool flat = false
    ) => await _repo.ReadAsync(page, pageSize, flat);

    public async Task<ResponseItemDto<UserDbm>> ReadItemAsync(string idOrName, bool flat = false) =>
        await _repo.ReadItemAsync(idOrName, flat);

    public async Task<ResponseItemDto<UserDbm>> DeleteAsync(string idOrName) =>
        await _repo.DeleteAsync(idOrName);

    public UserService(UsersDbRepo repo)
    {
        _repo = repo;
    }

    public UserService(UsersDbRepo repo, ILogger<UserService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
