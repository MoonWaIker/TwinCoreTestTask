using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using TwinCoreTestTask.Infrastructure.Services;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Utils;

public static class ServicesProviderExtensions
{
    private const string SendGridParameter = "Tokens:SendGrid";

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IRecordService, RecordService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<TimeProvider>();
        services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();
        services.AddScoped<ISendGridClient>(sp =>
        {
            var cfg = sp.GetRequiredService<IConfiguration>();

            return new SendGridClient(cfg[SendGridParameter]);
        });

        services.AddAutoMapperServices();
    }
}
