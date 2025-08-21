using System.Data;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using TwinCoreTestTask.DataBase.Enums;
using TwinCoreTestTask.Infrastructure.Services;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;
using TwinCoreTestTask.Infrastructure.Services.Schedule;
using TwinCoreTestTask.Infrastructure.Services.Schedule.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Utils;

public static class ServicesProviderExtensions
{
    private const string SendGridParameter = "Tokens:SendGrid";

    public static void AddServices(this IServiceCollection services)
    {
        var cfg = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddSingleton(TimeProvider.System);
        services.AddScoped<UserManager<IdentityUser>>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IRecordService, RecordService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserDeletionService, UserDeletionService>();
        services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();

        AddHangfire(services, cfg);

        services.AddScoped<ISendGridClient>(_ => new SendGridClient(cfg[SendGridParameter]
                                                                    ?? throw new NoNullAllowedException()));

        services.AddAutoMapperServices();
    }

    private static void AddHangfire(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserDeletionBackgroundJob, UserDeletionBackgroundJob>();

        services.AddHangfire(cfg =>
        {
            cfg
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            // TODO Make so the connection string is sharable
            .UseSqlServerStorage(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))
                                 ?? throw new NoNullAllowedException());
        });
        services.AddHangfireServer();

        BackgroundJob.Schedule<IUserDeletionBackgroundJob>(
            nameof(IUserDeletionBackgroundJob.DeleteNotActualUsers), static service => service.DeleteNotActualUsers(),
        TimeSpan.FromDays(1));
    }
}
