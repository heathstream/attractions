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

    public async Task<ResponseListDto<UserDbm>> ReadUsersAsync(int page, int pageSize) =>
        await _repo.ReadUsersAsync(page, pageSize);

    public async Task<ResponseItemDto<UserDbm>> ReadUserAsync(string idOrName) =>
        await _repo.ReadUserAsync(idOrName);

    public async Task<ResponseItemDto<UserDbm>> DeleteUserAsync(string idOrName) =>
        await _repo.DeleteUserAsync(idOrName);

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
