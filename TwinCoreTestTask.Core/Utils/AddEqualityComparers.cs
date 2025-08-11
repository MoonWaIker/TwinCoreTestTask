using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.Core.EqualityComparers;
using TwinCoreTestTask.Infrastructure.DTOs;

namespace TwinCoreTestTask.Core.Utils;

public static class AddEqualityComparers
{
    public static void AddCustomEqualityComparers(this IServiceCollection services)
    {
        services.AddScoped<IEqualityComparer<UserCredentials>, UserCredentialsEqualityComparers>();
    }
}
