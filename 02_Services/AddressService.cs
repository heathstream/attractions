using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace Services;

public class AddressService : IAddressService
{
    readonly CommentsDbRepo _repo = null;
    readonly ILogger<AddressService> _logger = null;

    public AddressService(CommentsDbRepo repo)
    {
        _repo = repo;
    }

    public AddressService(CommentsDbRepo repo, ILogger<AddressService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public Task<ResponseItemDto<AddressDbm>> DeleteAsync(string idOrName)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseListDto<AddressDbm>> ReadAsync(int page, int pageSize, bool flat = false)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseItemDto<AddressDbm>> ReadItemAsync(string idOrName, bool flat = false)
    {
        throw new NotImplementedException();
    }
}
