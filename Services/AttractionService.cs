using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class AttractionService : IAttractionService
{
    readonly AttractionsDbRepos _repo = null;
    readonly ILogger<AttractionService> _logger = null;

    public AttractionService(AttractionsDbRepos repo)
    {
        _repo = repo;
    }

    public AttractionService(AttractionsDbRepos repo, ILogger<AttractionService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    // public Task SeedAsync(int nrOfItems) { }
}
