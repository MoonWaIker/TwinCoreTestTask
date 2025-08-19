using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.DataBase.Contexts;

namespace TwinCoreTestTask.DataBase.Utils;

public static class DbContextProviderExtensions
{
    private const string ConnectionStringName = "DefaultConnection";

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<TwinCoreDbContext>(options =>
            options.UseSqlServer(services
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(ConnectionStringName)),
                // To avoid concurrent problems
                ServiceLifetime.Transient);
    }
}
