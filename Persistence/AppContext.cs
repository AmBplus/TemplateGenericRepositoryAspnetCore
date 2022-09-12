using System.Reflection;
using domain.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<User> users { get; set; }
    public DbSet<Role> Roles { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());    
        base.OnModelCreating(modelBuilder);
    }
}
