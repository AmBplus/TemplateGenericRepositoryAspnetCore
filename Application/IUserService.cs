using domain.UserAgg;

namespace Application;

public interface IUserService
{
    Task<User> Get(long id, bool isTrackAble = true);
    Task<UserDto> Get(long id);
    Task<UserDto> Search(string name);
    Task<IEnumerable<UserDto>> GetAll();
    Task<IEnumerable<UserDto>> GetAllBySearchName(string name);
}