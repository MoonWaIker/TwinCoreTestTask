using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.DataBase.Enums;

namespace TwinCoreTestTask.DataBase.Utils;

public static class DbContextProviderExtensions
{
    private static readonly string ConnectionStringName = ConnectionStrings.DefaultConnection.ToString();

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
