using domain.UserAgg;
using Persistence.GenericRepository;

namespace Persistence;

public class UserRepository :GenericRepository<User,long> , IUserRepository
{
    private  AppContext Context { get; }

    public UserRepository(AppContext context) : base(context)
    {
        Context = context;
    }

}