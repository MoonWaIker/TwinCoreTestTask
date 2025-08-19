using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace TwinCoreTestTask.Infrastructure.Utils;

public static class UserManagerExtensions
{
    public static async Task<IdentityUser> FindByEmailAsync(this UserManager<IdentityUser> userManager, MailAddress email)
    {
        return await userManager
                .FindByEmailAsync(email.Address)
                ?? throw new NotFoundException();
    }

    public static async Task UpdateAsync(this UserManager<IdentityUser> userManager, IdentityUser user)
    {
        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }
    }
}
