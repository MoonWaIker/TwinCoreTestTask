using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;
using TwinCoreTestTask.Infrastructure.Utils;

namespace TwinCoreTestTask.Infrastructure.Services;

// TODO USe UserManager where it's possible
public class UserDeletionService(TimeProvider timeProvider,
                                    UserManager<IdentityUser> userManager) : IUserDeletionService
{
    public async Task DeleteUserAsync(MailAddress email)
    {
        var user = await userManager.FindByEmailAsync(email);

        await userManager.SetLockoutEndDateAsync(user,
                timeProvider.GetUtcNow().AddDays(InfrastructureConstants.RecoveryPeriodDays));
        await userManager.SetLockoutEnabledAsync(user, true);

        await UserManagerExtensions.UpdateAsync(userManager, user);
    }

    public async Task RecoverAccountAsync(MailAddress email)
    {
        var user = await userManager.FindByEmailAsync(email);

        await userManager.SetLockoutEnabledAsync(user, false);

        await UserManagerExtensions.UpdateAsync(userManager, user);
    }
}
