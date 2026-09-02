using DbContext;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class AddressesDbRepo
{
    readonly ILogger<AddressesDbRepo> _logger;
    readonly MainDbContext _dbContext;

    public AddressesDbRepo(ILogger<AddressesDbRepo> logger, MainDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
}
