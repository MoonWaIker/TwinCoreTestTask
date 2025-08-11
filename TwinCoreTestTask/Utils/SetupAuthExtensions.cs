using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.Core.Utils;
using TwinCoreTestTask.DataBase.Contexts;

namespace TwinCoreTestTask.Utils;

public static class SetupAuthExtensions
{
    public static async Task ConfigureAuthAsync(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<TwinCoreDbContext>()
            .AddDefaultTokenProviders();

        await CreateRolesAsync(services
            .BuildServiceProvider()
            .GetRequiredService<RoleManager<IdentityRole>>());
    }

    public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync(RolesStrings.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(RolesStrings.Admin));
        }
    }
}
