using domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x=>x.RoleId);
        builder.HasData(new List<Role>()
        {
            new Role() {Id = 1 ,Name = "Admin" },
            new Role() {Id = 2 ,Name = "Customer" },
        });
    }
}