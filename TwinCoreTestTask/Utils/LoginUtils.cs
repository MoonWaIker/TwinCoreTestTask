using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace TwinCoreTestTask.Utils;

public static class LoginUtils
{
    public static Task AuthorizeUserAsync(this HttpContext context, IdentityUser<string> user)
    {
        return context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(
                new ClaimsIdentity(GetClaims(user), CookieAuthenticationDefaults.AuthenticationScheme)));
    }

    private static List<Claim> GetClaims(IdentityUser<string> user)
    {
        ArgumentNullException.ThrowIfNull(user.Email);

        // TODO Assign role
        return
        [
            new(ClaimTypes.Name, user.UserName ?? string.Empty),
            new(ClaimTypes.Email, user.Email),
        ];
    }
}
