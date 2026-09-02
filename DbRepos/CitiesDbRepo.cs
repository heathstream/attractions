using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class CitiesDbRepo
{
    readonly ILogger<CitiesDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public CitiesDbRepo(ILogger<CitiesDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
