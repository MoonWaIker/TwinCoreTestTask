namespace TwinCoreTestTask.Infrastructure.Services.Schedule.Interfaces;

public interface IUserDeletionBackgroundJob
{
    void DeleteNotActualUsers();
}
