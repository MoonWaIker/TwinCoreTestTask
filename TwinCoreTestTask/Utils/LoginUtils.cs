using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace TwinCoreTestTask.Utils;

// TODO Make it as a service
public static class LoginUtils
{
    public static async Task AuthorizeUserAsync(this HttpContext context,
        IdentityUser user,
        UserManager<IdentityUser> userManager)
    {
        await context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(
                new ClaimsIdentity(await GetClaimsAsync(user, userManager), CookieAuthenticationDefaults.AuthenticationScheme)));
    }

    private static async Task<IEnumerable<Claim>> GetClaimsAsync(IdentityUser user, UserManager<IdentityUser> userManager)
    {
        ArgumentNullException.ThrowIfNull(user.Email);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName ?? string.Empty),
            new(ClaimTypes.Email, user.Email),
        };

        claims
            .AddRange(from role
                    in await userManager
                        .GetRolesAsync(user)
                select new Claim(ClaimTypes.Role, role));

        return claims;
    }
}
