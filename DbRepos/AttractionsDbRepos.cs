using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class AttractionsDbRepos
{
    readonly ILogger<AttractionsDbRepos> _logger;
    readonly MainDbContext _dbContext;

    public AttractionsDbRepos(ILogger<AttractionsDbRepos> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
