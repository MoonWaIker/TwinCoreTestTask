using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwinCoreTestTask.DataBase.Entities;

namespace TwinCoreTestTask.DataBase.Contexts;

public class TwinCoreDbContext(DbContextOptions<TwinCoreDbContext> options)
    : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<RegisterInvitation> RegisterInvitations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseIdentityColumns();
    }
}
