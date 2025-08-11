using System.Diagnostics.CodeAnalysis;
using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Infrastructure.DTOs;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public class LoginService(TwinCoreDbContext dbContext, IEqualityComparer<UserCredentials> credentialsComparer) : ILoginService
{
    public bool TryValidateCredentials(UserCredentials credentials, [NotNullWhen(true)] out UserEntity user)
    {
        user = dbContext.Users
            .FirstOrDefault(user => credentialsComparer.Equals(credentials, user));

        return user != null;
    }
}
