using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class CountryService : ICountryService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<CountryService> _logger = null;

    public CountryService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public CountryService(CommentsDbRepo repo, ILogger<CountryService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
