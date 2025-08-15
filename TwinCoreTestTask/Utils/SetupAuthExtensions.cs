using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.DataBase.Contexts;

namespace TwinCoreTestTask.Utils;

public static class SetupAuthExtensions
{
    public static void ConfigureAuth(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
        services.AddAuthorization();

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<TwinCoreDbContext>()
            .AddDefaultTokenProviders();
    }
}
