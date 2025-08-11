using TwinCoreTestTask.Infrastructure.DTOs;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface ILoginService
{
    // TODO make it with try and out user data
    bool CredentialsAreValid(UserCredentials credentials);
}
