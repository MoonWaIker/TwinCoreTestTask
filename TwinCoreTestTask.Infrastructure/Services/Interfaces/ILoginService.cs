using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.Dtos.DTO;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface ILoginService
{
    void Register(Guid token, UserRegister registratingUser);

    // TODO make separate entity if the UserEntity model contains unnecessary fields
    bool TryValidateCredentials(UserCredentials credentials, out IdentityUser? user);
}
