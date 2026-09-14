using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

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

    public Task<ResponseItemDto<RatingDbm>> DeleteAsync(string idOrName)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseListDto<RatingDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseItemDto<RatingDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        throw new NotImplementedException();
    }
}
