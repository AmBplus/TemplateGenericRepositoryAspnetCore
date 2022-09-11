using System.Linq.Expressions;
using Shared;

namespace domain.UserAgg;

public interface IUserRepository : IGenericRepository<User, long>
{

}