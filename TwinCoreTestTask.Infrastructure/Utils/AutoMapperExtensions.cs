using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Infrastructure.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Utils;

internal static class AutoMapperExtensions
{
    internal static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<RecordDto, RecordEntity>()
                .ReverseMap(); // This will create a two-way mapping between RecordDto and RecordEntity
        });
        services.AddScoped<IAutoMapper, Services.AutoMapper>();

        return services;
    }
}
