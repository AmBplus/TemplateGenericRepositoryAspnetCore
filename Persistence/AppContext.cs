using domain.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<User> users { get; set; }
}
