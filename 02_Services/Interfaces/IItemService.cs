using DbModels;
using Models.Dto;

namespace Services;

public interface IItemService<T>
{
    public Task<ResponseListDto<T>> ReadAsync(int page, int pageSize, bool flat = false);
    public Task<ResponseItemDto<T>> ReadItemAsync(string idOrName, bool flat = false);
    public Task<ResponseItemDto<T>> DeleteAsync(string idOrName);
}

public interface IAttractionService : IItemService<AttractionDbm> { }

public interface IUserService : IItemService<UserDbm> { }

public interface IAddressService : IItemService<AddressDbm> { }

public interface ICityService : IItemService<CityDbm> { }

public interface ICountryService : IItemService<CountryDbm> { }

public interface ICommentService : IItemService<CommentDbm> { }

public interface IRatingService : IItemService<RatingDbm> { }
