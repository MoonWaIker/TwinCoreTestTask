using System.Data;
using AutoMapper;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Dtos.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public sealed class AutoMapper(IMapper mapper) : IAutoMapper
{
    public RecordEntity Map(RecordDto source)
    {
        return mapper.Map<RecordEntity>(source)
               ?? throw new NoNullAllowedException();
    }

    public IEnumerable<RecordDto> Map(IEnumerable<RecordEntity> source)
    {
        return mapper.Map<IEnumerable<RecordEntity>, IEnumerable<RecordDto>>(source)
               ?? throw new NoNullAllowedException();
    }
}
