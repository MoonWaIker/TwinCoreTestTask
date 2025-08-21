using System.Data;
using Microsoft.Extensions.DependencyInjection;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Dtos.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Utils;

internal static class AutoMapperExtensions
{
    internal static void AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(static cfg =>
        {
            (cfg.CreateMap<RecordDto, RecordEntity>() ?? throw new NoNullAllowedException())
                .ReverseMap(); // This will create a two-way mapping between RecordDto and RecordEntity
        });
        services.AddScoped<IAutoMapper, Services.AutoMapper>();
    }
}
