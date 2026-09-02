using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class CityService : ICityService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<CityService> _logger = null;

    public CityService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public CityService(CommentsDbRepo repo, ILogger<CityService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
