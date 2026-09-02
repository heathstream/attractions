using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class UserService : IUserService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<UserService> _logger = null;

    public UserService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public UserService(CommentsDbRepo repo, ILogger<UserService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
