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
    // Not Good Idea Use Directly User In EndPoint
    // But For Show You How Use This Generic Repository I Implemented
    // So You Can Easily Remove Form Application Layer
    public async Task<User> Get(long id , bool isTrack = true)
    {
       // Can Get User with All Parameter Like Bellow
       var user  = await _userRepository.Get(
         filter:x => x.Id == id,
         select: x => new User()
         {
             FullName = x.FullName,
             Id = x.Id,
             Role = new Role()
             {
                 Name = x.Role.Name,
                 Users = x.Role.Users
             }
         }  ,
         include: $"{nameof(Role)},{nameof(Role)}.{nameof(Role.Users)}",
         isTrackable: isTrack
       );

       return user;

       // In Above Code Generated Query Just Go And Get The Selected Properties
       // And  Filtering are In Database Not Application
       // Then In Repository Class Connection Become Close
       // And Result Return To Application(Service) Layer
    }
    public async Task<UserDto> Get(long id)
    {
        // Just Get Directly UserDto Like Bellow
        return await _userRepository.Get<UserDto>(filter: x => x.Id == 1);

    }
    public async Task<UserDto> Search(string name)
    {
        var result = await _userRepository.Get<UserDto>(filter: x => x.Name.Contains("a"));
        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        return await _userRepository.GetAll<UserDto>();
    }

    public async Task<IEnumerable<UserDto>> GetAllBySearchName(string name)
    {
        var result = await _userRepository.GetAll<UserDto>(filter: x => x.Name.Contains("a"));
        return result;
    }
}