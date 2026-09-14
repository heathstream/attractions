using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

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

    public Task<ResponseItemDto<CityDbm>> DeleteAsync(string idOrName)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseListDto<CityDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseItemDto<CityDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        throw new NotImplementedException();
    }
}
