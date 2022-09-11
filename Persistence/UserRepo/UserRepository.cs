using domain.UserAgg;
using Persistence.GenericRepository;

namespace Persistence.UserRepo;

public class UserRepository : GenericRepository<User,long> , IUserRepository
{
    private AppContext Context { get; }
    public UserRepository(AppContext context): base(context:context)
    {
        Context = context;
    }
}