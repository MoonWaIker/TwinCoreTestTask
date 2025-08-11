using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TwinCoreTestTask.DataBase.Entities;

namespace TwinCoreTestTask.Utils;

public static class LoginUtils
{
    public static Task AuthorizeUserAsync(this HttpContext context, UserEntity user)
    {
        return context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(
                new ClaimsIdentity(GetClaims(user), CookieAuthenticationDefaults.AuthenticationScheme)));
    }

    private static List<Claim> GetClaims(UserEntity user)
    {
        return
        [
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(ClaimTypes.NameIdentifier, user.Email) // Using email as identifier since no primary key
        ];
    }
}
