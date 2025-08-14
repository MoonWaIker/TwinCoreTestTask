using AutoMapper;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Infrastructure.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public class AutoMapper(IMapper mapper) : IAutoMapper
{
    public RecordEntity Map(RecordDto source)
    {
        return mapper.Map<RecordEntity>(source);
    }

    public IEnumerable<RecordDto> Map(IEnumerable<RecordEntity> source)
    {
        return mapper.Map<IEnumerable<RecordEntity>, IEnumerable<RecordDto>>(source);
    }
}
