using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Services;

public class CommentService : ICommentService
{
    readonly AttractionsDbRepos _repo = null;
    readonly ILogger<CommentService> _logger = null;

    public CommentService(AttractionsDbRepos repo)
    {
        _repo = repo;
    }

    public CommentService(AttractionsDbRepos repo, ILogger<CommentService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
