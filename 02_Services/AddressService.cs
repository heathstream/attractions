using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

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
}
