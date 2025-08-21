using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.Infrastructure.Services.Schedule.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services.Schedule;

public sealed class UserDeletionBackgroundJob(TwinCoreDbContext dbContext, TimeProvider timeProvider)
    : IUserDeletionBackgroundJob
{
    public void DeleteNotActualUsers()
    {
        dbContext.RemoveRange(dbContext.Users
            .Where(user => user.LockoutEnabled
                && user.LockoutEnd.HasValue
                && user.LockoutEnd.Value < timeProvider.GetUtcNow()));

        dbContext.SaveChanges();
    }
}
