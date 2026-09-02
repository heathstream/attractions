using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class AttractionsDbRepo
{
    readonly ILogger<AttractionsDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public AttractionsDbRepo(ILogger<AttractionsDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
