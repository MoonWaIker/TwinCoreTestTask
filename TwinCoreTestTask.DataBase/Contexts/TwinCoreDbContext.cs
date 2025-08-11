using Microsoft.EntityFrameworkCore;
using TwinCoreTestTask.DataBase.Entities;

namespace TwinCoreTestTask.DataBase.Contexts;

public class TwinCoreDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
}
