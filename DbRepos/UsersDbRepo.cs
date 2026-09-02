using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class UsersDbRepo
{
    readonly ILogger<UsersDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public UsersDbRepo(ILogger<UsersDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
