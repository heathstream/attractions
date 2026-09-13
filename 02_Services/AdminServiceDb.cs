using DbModels;
using DbRepos;
using Microsoft.Extensions.Logging;

namespace Services;

public class AdminServiceDb : IAdminService
{
    private readonly AdminDbRepo _repo = null;
    private readonly ILogger<AdminServiceDb> _logger = null;

    public async Task SeedAsync(
        int attractionsCount,
        int usersCount,
        int citiesCount,
        int countriesCount,
        int addressesCount
    ) =>
        await _repo.SeedAsync(
            attractionsCount,
            usersCount,
            citiesCount,
            countriesCount,
            addressesCount
        );

    #region constructors
    public AdminServiceDb(AdminDbRepo repo)
    {
        _repo = repo;
    }

    public AdminServiceDb(AdminDbRepo repo, ILogger<AdminServiceDb> logger)
        : this(repo)
    {
        _logger = logger;
    }
    #endregion
}
