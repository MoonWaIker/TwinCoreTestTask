using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.DataBase.Utils;

namespace TwinCoreTestTask.DataBase.Contexts;

// README since number key are prohibited according to the task, you can mention that all entities are keyless.
public class TwinCoreDbContext(DbContextOptions<TwinCoreDbContext> options)
    : IdentityDbContext<IdentityUser, IdentityRole, string>(options)
{
    public DbSet<RecordEntity> Records { get; set; }

    public DbSet<RegisterInvitation> RegisterInvitations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseIdentityColumns();
        builder.Entity<IdentityRole>().HasData(RolesExecutor.Roles);
    }
}
