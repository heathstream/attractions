using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class CountriesDbRepo
{
    readonly ILogger<CountriesDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public CountriesDbRepo(ILogger<CountriesDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
