using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Mapster;
using domain.UserAgg;

namespace Application;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDto> Get(long id)
    {
       return _userRepository.Get<UserDto>(filter: x => x.Id == 1).Result;
    }

    public async Task<UserDto> Search(string name)
    {
        var result = _userRepository.Get<UserDto>(filter: x => x.Name.Contains("a")).Result;
        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        return _userRepository.GetAll<UserDto>(filter: x => x.Id < 3).Result;
    }

    public async Task<IEnumerable<UserDto>> GetAllBySearchName(string name)
    {
        var result = _userRepository.GetAll<UserDto>(filter: x => x.Name.Contains("a")).Result;
        return result;
    }
}