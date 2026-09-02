using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class CommentsDbRepo
{
    readonly ILogger<CommentsDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public CommentsDbRepo(ILogger<CommentsDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
