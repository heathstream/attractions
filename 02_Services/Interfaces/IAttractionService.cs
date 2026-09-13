using DbModels;
using Models.Dto;

namespace Services;

public interface IAttractionService
{
    public Task<ResponseListDto<AttractionDbm>> ReadAttractionsAsync(int page, int pageSize);
    public Task<ResponseItemDto<AttractionDbm>> ReadAttractionAsync(string idOrName);
    public Task<ResponseItemDto<AttractionDbm>> DeleteAttractionAsync(string idOrName);
}
