using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.Dto.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

// TODO Mediator required
public sealed class LoginService(
    TwinCoreDbContext dbContext,
                            TimeProvider timeProvider,
                            IPasswordHasher<IdentityUser> passwordHasher) : ILoginService
{
    public bool TryValidateCredentials(UserCredentials credentials, out IdentityUser? user)
    {
        // TODO Maybe you can handle it by Middleware
        user = dbContext.Users
            .First(user => credentials.Email == user.Email);

        return passwordHasher.VerifyHashedPassword(user, user.PasswordHash
                                                         ?? string.Empty, credentials.Password) ==
               PasswordVerificationResult.Success;
    }

    public void Register(Guid token, UserRegister registratingUser)
    {
        var invitation = dbContext.RegisterInvitations
            .First(i => i.Token == token);

        if (invitation.ExpiresAt < timeProvider.GetUtcNow())
        {
            throw new SecurityTokenExpiredException();
        }

        var user = new IdentityUser
        {
            Email = registratingUser.Email,
            UserName = registratingUser.UserName,
        };
        user.PasswordHash = passwordHasher.HashPassword(user, registratingUser.Password);
        dbContext.Users.Add(user);

        dbContext.RegisterInvitations.Remove(invitation);

        dbContext.SaveChanges();
    }
}
