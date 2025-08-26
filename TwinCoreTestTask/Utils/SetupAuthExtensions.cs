using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.DataBase.Contexts;

namespace TwinCoreTestTask.Utils;

public static class SetupAuthExtensions
{
    public static void ConfigureAuth(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.TimeProvider = services.BuildServiceProvider().GetRequiredService<TimeProvider>();
            options.DataProtectionProvider?.CreateProtector(CookieAuthenticationDefaults.AuthenticationScheme);
            options.Cookie.HttpOnly = true;
        });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
        services.AddAuthorization();

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddSignInManager<SignInManager<IdentityUser>>()
            .AddEntityFrameworkStores<TwinCoreDbContext>()
            .AddDefaultTokenProviders();
    }
}
