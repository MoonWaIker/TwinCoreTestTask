namespace TwinCoreTestTask.Utils;

public static class SetupBruteForceExtension
{
    public static void ConfigureBruteForceProtection(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddNoBrute();
    }
}
