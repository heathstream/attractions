using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class RatingsDbRepo
{
    readonly ILogger<RatingsDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public RatingsDbRepo(ILogger<RatingsDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
