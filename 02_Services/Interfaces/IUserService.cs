using DbModels;
using Models.Dto;

namespace Services;

public interface IUserService
{
    public Task<ResponseListDto<UserDbm>> ReadUsersAsync(int page, int pageSize);
    public Task<ResponseItemDto<UserDbm>> ReadUserAsync(string idOrName);
    public Task<ResponseItemDto<UserDbm>> DeleteUserAsync(string idOrName);
}
