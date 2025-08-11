using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.Infrastructure.Services;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Utils;

public static class ServicesProviderExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
    }
}
