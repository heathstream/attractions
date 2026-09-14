using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

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

    public Task<ResponseItemDto<CountryDbm>> DeleteAsync(string idOrName)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseListDto<CountryDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseItemDto<CountryDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        throw new NotImplementedException();
    }
}
