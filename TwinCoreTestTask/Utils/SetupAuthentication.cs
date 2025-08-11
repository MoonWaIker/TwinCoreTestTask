using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace TwinCoreTestTask.Utils;

public static class SetupAuthentication
{
    public static async Task ConfigureAuthAsync(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            // .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

        await CreateRolesAsync(services
            .BuildServiceProvider()
            .GetRequiredService<RoleManager<IdentityRole>>());
    }

    public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }
}
