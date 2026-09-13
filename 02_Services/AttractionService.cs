using DbModels;
using DbRepos;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Models.Dto;

namespace Services;

public class AttractionService : IAttractionService
{
    readonly AttractionsDbRepo _repo = null;
    readonly ILogger<AttractionService> _logger = null;

    public async Task<ResponseListDto<AttractionDbm>> ReadAttractionsAsync(
        int page,
        int pageSize
    ) => await _repo.ReadAttractionsAsync(page, pageSize);

    public async Task<ResponseItemDto<AttractionDbm>> ReadAttractionAsync(string idOrName) =>
        await _repo.ReadAttractionAsync(idOrName);

    public async Task<ResponseItemDto<AttractionDbm>> DeleteAttractionAsync(string idOrName) =>
        await _repo.DeleteAttractionAsync(idOrName);

    public AttractionService(AttractionsDbRepo repo)
    {
        _repo = repo;
    }

    public AttractionService(AttractionsDbRepo repo, ILogger<AttractionService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
