using System.Diagnostics.CodeAnalysis;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Infrastructure.DTOs;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface ILoginService
{
    // TODO make separate entity if the UserEntity model contains unnecessary fields
    bool TryValidateCredentials(UserCredentials credentials, [NotNullWhen(true)] out UserEntity user);
}
