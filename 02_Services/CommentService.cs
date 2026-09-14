using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace Services;

public class CommentService : ICommentService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<CommentService> _logger = null;

    public CommentService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public CommentService(CommentsDbRepo repo, ILogger<CommentService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public Task<ResponseItemDto<CommentDbm>> DeleteAsync(string idOrName)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseListDto<CommentDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseItemDto<CommentDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        throw new NotImplementedException();
    }
}
