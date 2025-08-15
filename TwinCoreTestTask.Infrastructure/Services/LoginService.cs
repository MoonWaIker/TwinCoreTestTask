using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.Infrastructure.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

// TODO Mediator required
public class LoginService(TwinCoreDbContext dbContext,
                            TimeProvider timeProvider,
                            IPasswordHasher<IdentityUser> passwordHasher) : ILoginService
{
    public bool TryValidateCredentials(UserCredentials credentials, [NotNullWhen(true)] out IdentityUser user)
    {
        // TODO Maybe you can handle that by Middleware
        user = dbContext.Users
            .FirstOrDefault(user => AreCredentialsEqual(credentials, user));

        return user != null;
    }

    public void Register(Guid token, UserRegister registratingUser)
    {
        var invitation = dbContext.RegisterInvitations.First(i => i.Token == token);

        if (invitation.ExpiresAt < timeProvider.GetUtcNow())
        {
            throw new SecurityTokenExpiredException();
        }

        var user = new IdentityUser
        {
            Email = registratingUser.Email,
            UserName = registratingUser.Email,
        };
        passwordHasher.HashPassword(user, registratingUser.Password);
        dbContext.Users.Add(user);

        dbContext.RegisterInvitations.Remove(invitation);

        dbContext.SaveChanges();
    }

    private bool AreCredentialsEqual(UserCredentials credentials, IdentityUser user)
    {
        ArgumentNullException.ThrowIfNull(user.PasswordHash);

        return user.Email == credentials.Email
                && passwordHasher.VerifyHashedPassword(user, user.PasswordHash, credentials.Password) == PasswordVerificationResult.Success;
    }
}
