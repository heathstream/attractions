using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class CommentsDbRepos
{
    readonly ILogger<CommentsDbRepos> _logger;
    readonly MainDbContext _dbContext;

    public CommentsDbRepos(ILogger<CommentsDbRepos> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
