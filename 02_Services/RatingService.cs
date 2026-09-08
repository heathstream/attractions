using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class RatingService : IRatingService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<RatingService> _logger = null;

    public RatingService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public RatingService(CommentsDbRepo repo, ILogger<RatingService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
